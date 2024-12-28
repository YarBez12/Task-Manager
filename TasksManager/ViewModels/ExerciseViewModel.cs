using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;
using TasksManager.Services;

namespace TasksManager.ViewModels;

[QueryProperty(nameof(Date), "SelectedDate")]
public partial class ExerciseViewModel : ObservableObject
{
    public ObservableCollection<int> Hours { get; } = new ObservableCollection<int>(Enumerable.Range(0, 24));
    public ObservableCollection<int> Minutes { get; } = new ObservableCollection<int>(Enumerable.Range(0, 60));
    private readonly ExerciseService _exerciseService;
    private readonly TaskService _taskService;
    
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
    }

    public int Id { get; internal set; }

    [ObservableProperty]
    private string essence;

    [ObservableProperty]
    private DateTime date;

    [ObservableProperty]
    private TimeSpan duration;

    [ObservableProperty]
    private bool isCompleted;

    [ObservableProperty]
    private bool isExpired;

    [ObservableProperty]
    private int priority;

    [ObservableProperty] 
    private bool isLast;

    public int TaskId { get; set; } 
    
    [ObservableProperty]
    private ObservableCollection<TasksManager.Models.Task> tasks;

    [ObservableProperty]
    private TasksManager.Models.Task selectedTask;

    public ExerciseViewModel(Exercise exercise, ExerciseService exerciseService = null)
    {
        _taskService = new TaskService();
        _exerciseService = exerciseService ?? new ExerciseService();
        Id = exercise.Id;
        Essence = exercise.Essence;
        Date = exercise.Date;
        Duration = exercise.Duration;
        IsCompleted = exercise.IsCompleted;
        IsExpired = exercise.IsExpired;
        Priority = exercise.Priority;
        TaskId = exercise.TaskId;
        IsLast = exercise.IsLast;
        LoadTasksAsync();
    }
    
    private async void LoadTasksAsync()
    {
        var taskList = await _taskService.GetTasksAsync();
        if (TaskId != 0)
        {
            SelectedTask = await _taskService.GetTaskByIdAsync(TaskId);
            TaskName = SelectedTask.Title;
        }
        Tasks = new ObservableCollection<TasksManager.Models.Task>(taskList.Where(t => !t.IsCompleted));
    }


    public ExerciseViewModel()
    {
        _taskService = new TaskService();
        _exerciseService = new ExerciseService();
        Date = DateTime.Now.Date;
        Duration = TimeSpan.FromHours(1);
        LoadTasksAsync();
    }

    // public void Initialize(DateTime date)
    // {
    //     Date = date;
    // }
    
    [RelayCommand]
    private async System.Threading.Tasks.Task Save()
    {
        var newExercise = new Exercise
        {
            Essence = Essence,
            Date = Date,
            Duration = Duration,
            TaskId = SelectedTask.Id,
            IsLast = IsLast
            
        };

        Id = await _exerciseService.AddExerciseAsync(newExercise);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private void Cancel()
    {
        Shell.Current.GoToAsync("..");
    }
}