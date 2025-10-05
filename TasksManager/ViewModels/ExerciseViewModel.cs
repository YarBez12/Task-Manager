using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;
using TasksManager.Services;

namespace TasksManager.ViewModels;

[QueryProperty(nameof(Date), "SelectedDate")]
public partial class ExerciseViewModel : ObservableObject
{
    private ExerciseValidator _validator = new();
    private ExerciseViewModel? _copiedExercise;
    public ObservableCollection<int> Hours { get; } = new ObservableCollection<int>(Enumerable.Range(0, 24));
    public ObservableCollection<int> Minutes { get; } = new ObservableCollection<int>(Enumerable.Range(0, 60));
    private readonly ExerciseService _exerciseService;
    private readonly TaskService _taskService;
    private BufferService _bufferService = new BufferService();
    private bool _suppressIsLastCheck;

    [ObservableProperty] 
    private bool isTaskFieldEnabled = true;

    [ObservableProperty] 
    private bool isDateNotSet = false;

    [ObservableProperty] 
    private Color bgColor;
    
    [ObservableProperty]
    private int selectedHour;

    partial void OnSelectedHourChanged(int value)
    {
        UpdateDuration();
    }

    [ObservableProperty]
    private int selectedMinute;

    partial void OnSelectedMinuteChanged(int value)
    {
        UpdateDuration();
    }
    
    [ObservableProperty]
    private string taskName;
    
    private void UpdateDuration()
    {
        Duration = new TimeSpan(SelectedHour, SelectedMinute, 0);
        Console.WriteLine();
    }

    private void UpdateDurationView()
    {
        SelectedHour = Duration.Hours;
        SelectedMinute = Duration.Minutes;
    }

    public int Id { get; internal set; }

    [ObservableProperty]
    private string essence;

    [ObservableProperty]
    private DateTime date;

    [ObservableProperty]
    private TimeSpan duration;

    // partial void OnDurationChanged(TimeSpan value)
    // {
    //     UpdateDurationView();
    // }

    [ObservableProperty]
    private bool isCompleted;

    [ObservableProperty]
    private bool isExpired;

    [ObservableProperty]
    private int priority;

    [ObservableProperty] 
    private bool isLast;

    partial void OnIsLastChanged(bool value)
    {
        if (_suppressIsLastCheck) return;
        UpdateLastExerciseStatusAsync();
    }
    
    private async System.Threading.Tasks.Task UpdateLastExerciseStatusAsync()
    {
        if (IsLast)
        {
            // var allExercises = (await _exerciseService.GetExercisesAsync()).Where(e => e.TaskId == TaskId && e.IsLast && e.Id != Id);
            var allExercises =
                (await _exerciseService.GetExercisesAsync()).Where(e => e.TaskId == TaskId && e.Id != Id);
            var uncompletedExercises = allExercises.Where(e => !e.IsCompleted).ToList();
            if (uncompletedExercises.Count > 0)
            {
                IsLast = false;
                App.Current.MainPage.DisplayAlert("Error", "There are some uncompleted exercises on this task", "OK");
                return;
            }
            var lastExercises = allExercises.Where(e => e.IsLast).ToList();
            foreach (var exercise in lastExercises)
            {
                exercise.IsLast = false;
                await _exerciseService.UpdateExerciseAsync(exercise);
            }
        }
    }

    [ObservableProperty] 
    private int taskId;

    [ObservableProperty] 
    private string updateButtonText = "\u2714\ufe0f";

    [ObservableProperty] 
    private bool isNotCompleted;

    partial void OnIsCompletedChanged(bool value)
    {
        if (value)
        {
            IsNotCompleted = false;
            UpdateButtonText = "↩️";
            BgColor = Color.FromArgb("#9ACD32");
        }
        else if (IsExpired)
        {
            IsNotCompleted = true;
            UpdateButtonText = "\u2714\ufe0f";
            BgColor = Color.FromArgb("#FFB6C1");
        }
        else
        {
            IsNotCompleted = true;
            UpdateButtonText = "\u2714\ufe0f";
            BgColor = Color.FromArgb("#FFA500");
        }
    }

    partial void OnTaskIdChanged(int value)
    {
        if (Tasks != null)
        {
            SelectedTask = Tasks.FirstOrDefault(t => t.Id == TaskId);
            TaskName = SelectedTask?.Title ?? string.Empty;
        }
    }
    
    [ObservableProperty]
    private ObservableCollection<TasksManager.Models.Task> tasks;

    [ObservableProperty]
    private TasksManager.Models.Task selectedTask;

    public ExerciseViewModel(Exercise exercise, ExerciseService exerciseService = null)
    {
        _taskService = new TaskService();
        _exerciseService = exerciseService ?? new ExerciseService();
        _suppressIsLastCheck = true;
        Id = exercise.Id;
        Essence = exercise.Essence;
        Date = exercise.Date;
        SelectedMinute = exercise.Duration.Minutes;
        SelectedHour = exercise.Duration.Hours;
        // Duration = exercise.Duration;
        // SelectedMinute = exercise.Duration.Minutes;
        // SelectedHour = exercise.Duration.Hours;
        IsExpired = exercise.IsExpired;
        IsCompleted = exercise.IsCompleted;
        Priority = exercise.Priority;
        TaskId = exercise.TaskId;
        IsLast = exercise.IsLast;
        _suppressIsLastCheck = false;
        LoadTasksAsync();
    }
    
    private async void LoadTasksAsync()
    {
        var taskList = await _taskService.GetTasksAsync();
        Tasks = new ObservableCollection<TasksManager.Models.Task>(taskList.Where(t => !t.IsCompleted || t.Id == TaskId));
        if (TaskId != 0)
        {
            SelectedTask = taskList.FirstOrDefault(t => t.Id == TaskId);
        }
        else
        {
            SelectedTask = Tasks[0];
            Console.WriteLine();
        }
        TaskName = SelectedTask?.Title ?? string.Empty;
    }


    public ExerciseViewModel()
    {
        _taskService = new TaskService();
        _exerciseService = new ExerciseService();
        Date = DateTime.Now.Date;
        SelectedHour = 1;
        LoadTasksAsync();
    }

    // public void Initialize(DateTime date)
    // {
    //     Date = date;
    // }
    
    [RelayCommand]
    private async System.Threading.Tasks.Task Save()
    {
        var result = await _validator.ValidateAsync(new TasksManager.Models.Exercise
        {
            Essence = Essence
        });

        if (!result.IsValid)
        {
            var errorMessages = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
            await Application.Current.MainPage.DisplayAlert("Validation Error", errorMessages, "OK");
            return;
        }
        if (Id <= 0)
        {
            var newExercise = new Exercise
            {
                Essence = Essence,
                Date = Date,
                Duration = Duration,
                TaskId = SelectedTask.Id,
                IsLast = IsLast

            };

            await _exerciseService.AddExerciseAsync(newExercise);
            // Id = await _exerciseService.AddExerciseAsync(newExercise);
            Id = newExercise.Id;
        }
        else
        {
            var existingExercise = await App.ExerciseRepository.GetExerciseByIdAsync(Id);
            if (existingExercise != null)
            {
                existingExercise.Essence = Essence;
                existingExercise.Duration = Duration;
                existingExercise.TaskId = SelectedTask.Id;
                existingExercise.IsLast = IsLast;
                
                await _exerciseService.UpdateExerciseAsync(existingExercise);
            }
        }
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private void Cancel()
    {
        Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private void CopyExercise()
    {
        _bufferService.Copy<ExerciseViewModel>(this);
    }
    [RelayCommand]
    public void PasteExercise()
    {
        var copiedExercise = _bufferService.Paste<ExerciseViewModel>();
        if (copiedExercise != null)
        {
            Essence = copiedExercise.Essence;
            SelectedMinute = copiedExercise.Duration.Minutes;
            SelectedHour = copiedExercise.Duration.Hours;
            // Duration = copiedExercise.Duration;
            // SelectedMinute = Duration.Minutes;
            // SelectedHour = Duration.Hours;
            TaskId = copiedExercise.TaskId;
            IsLast = copiedExercise.IsLast;
        }
    }
}