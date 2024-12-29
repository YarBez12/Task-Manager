using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;
using TasksManager.Services;
using TasksManager.Views;

// using Task = TasksManager.Models.Task;

namespace TasksManager.ViewModels;

public partial class TaskViewModel : ObservableObject
{
    private readonly TaskService _taskService;
    public int Id { get; internal set; }

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private string description;

    [ObservableProperty]
    private DateTime dueDate;

    [ObservableProperty]
    private TaskPriority priority;

    [ObservableProperty]
    private bool isCompleted;
    [ObservableProperty]
    private string isCompletedText;
    [ObservableProperty]
    private Color isCompletedColor;
    
    [ObservableProperty]
    private TaskCategory category;
    
    [ObservableProperty]
    private TaskOverdueStatus overdueStatus;
    
    [ObservableProperty]
    private string completeText;
    
    private ExerciseService _exerciseService;
    
    [ObservableProperty]
    private ObservableCollection<Exercise> exercises;

    // public bool IsOverdue => !IsCompleted && DateTime.Now > DueDate;

    // public TaskViewModel(int id, string title, string description, DateTime dueDate, TaskPriority priority, TaskService taskService = null)
    // {
    //     _taskService = taskService ?? new TaskService();
    //     Id = id;
    //     Title = title;
    //     Description = description;
    //     DueDate = dueDate;
    //     Priority = priority;
    //     IsCompleted = false;
    // }

    private async void LoadExercises()
    {
        var allExercises = await _exerciseService.GetExercisesAsync();
        Exercises = new ObservableCollection<Exercise>(allExercises.Where(e => e.TaskId == Id));
    }

    public TaskViewModel(TasksManager.Models.Task task, TaskService taskService = null)
    {
        _exerciseService = new ExerciseService();
        _taskService = taskService ?? new TaskService();
        Id = task.Id;
        title = task.Title;
        description = task.Description;
        dueDate = task.DueDate;
        priority = task.Priority;
        category = task.Category;
        overdueStatus = task.OverdueStatus;
        isCompleted = task.IsCompleted;
        if (IsCompleted)
        {
            IsCompletedColor = Color.FromRgb(152, 251, 152);
            isCompletedText = "Completed";
            CompleteText = "Unfinish";
        }
        else
        {
            IsCompletedColor = Color.FromRgb(255, 192, 203);
            isCompletedText = "Not Completed";
            CompleteText = "Complete";
        }
        UpdateTimeRemaining();
        StartOverdueStatusUpdater();
        LoadExercises();
    }
    public TaskViewModel(TaskService taskService = null)
    {
        _exerciseService = new ExerciseService();
        _taskService = taskService ?? new TaskService();
        DueDate = DateTime.Now;
        Priority = TaskPriority.Medium;
        overdueStatus = TaskOverdueStatus.Upcoming;
        Category = TaskCategory.Work;
        UpdateTimeRemaining();
        StartOverdueStatusUpdater();
        LoadExercises();
    }
    public TaskViewModel()
    {
        _exerciseService = new ExerciseService();
        _taskService = new TaskService();
        DueDate = DateTime.Now;
        Priority = TaskPriority.Medium;
        overdueStatus = TaskOverdueStatus.Upcoming;
        Category = TaskCategory.Work;
        UpdateTimeRemaining();
        StartOverdueStatusUpdater();
        LoadExercises();
    }
    
    public ObservableCollection<TaskPriority> Priorities { get; } =
        new ObservableCollection<TaskPriority>((TaskPriority[])Enum.GetValues(typeof(TaskPriority)));
    
    public ObservableCollection<TaskCategory> Categories { get; } =
        new ObservableCollection<TaskCategory>((TaskCategory[])Enum.GetValues(typeof(TaskCategory)));
    
    // public TaskViewModel CopyFrom(Task task)
    // {
    //     Id = task.Id;
    //     Title = task.Title;
    //     Description = task.Description;
    //     DueDate = task.DueDate;
    //     Priority = task.Priority;
    //     IsCompleted = task.IsCompleted;
    //     return this;
    // }
    
    [RelayCommand]
    public async System.Threading.Tasks.Task SaveTask()
    {
        if (Id <= 0)
        {
            var newTask = new TasksManager.Models.Task
            {
                // Id = Id,
                Title = Title,
                Description = Description,
                DueDate = DueDate,
                Priority = Priority,
                Category = Category,
                OverdueStatus = OverdueStatus,
                IsCompleted = IsCompleted
            };

            // Id = await _taskService.AddTaskAsync(newTask);
            await _taskService.AddTaskAsync(newTask);
            Id = newTask.Id;
            // var tt = await App.TaskRepository.GetTasksAsync();
            // foreach (var t in tt)
            // {
            //     Console.WriteLine(t.Title + " - " + t.Id);
            // }
            // Console.WriteLine($"Added new task: {Id}");
            // Id = newTask.Id;
        }
        else 
        {
            var existingTask = await _taskService.GetTaskByIdAsync(Id);
            if (existingTask != null)
            {
                // existingTask.Id = Id;
                existingTask.Title = Title;
                existingTask.Description = Description;
                existingTask.DueDate = DueDate;
                existingTask.Priority = Priority;
                existingTask.Category = Category;
                existingTask.IsCompleted = IsCompleted;
                existingTask.OverdueStatus = OverdueStatus;

                await _taskService.UpdateTaskAsync(existingTask); 
            }
        }
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public void Cancel()
    {
        Shell.Current.GoToAsync("..");
    }
    
    partial void OnDueDateChanged(DateTime value)
    {
        var daysOverdue = (DateTime.Now.Date - value.Date).Days;

        OverdueStatus = daysOverdue switch
        {
            < 0 => TaskOverdueStatus.Upcoming,
            0 => TaskOverdueStatus.Today,
            <= 7 => TaskOverdueStatus.Recent,
            _ => TaskOverdueStatus.Critical,
        };
    }

    partial void OnIsCompletedChanged(bool value)
    {
        if (value)
        {
            IsCompletedColor = Color.FromRgb(152, 251, 152);
            IsCompletedText = "Completed";
            CompleteText = "Unfinish";
        }
        else
        {
            IsCompletedColor = Color.FromRgb(255, 192, 203);
            IsCompletedText = "Not Completed";
            CompleteText = "Complete";
        }
    }
    
    [ObservableProperty]
    private string timeRemaining;

    public TasksManager.Models.Task Task { get; }
    
    private void ScheduleMinuteUpdate(Action action)
    {
        var now = DateTime.Now;
        var nextMinute = now.AddMinutes(1).AddSeconds(-now.Second);
        var timeUntilNextMinute = nextMinute - now;
        Timer timer = null;
        timer = new Timer(_ =>
        {
            action.Invoke();
            timer?.Dispose();
            ScheduleMinuteUpdate(action);
        }, null, timeUntilNextMinute, Timeout.InfiniteTimeSpan);
    }
    
    private void StartOverdueStatusUpdater()
    {
        ScheduleMinuteUpdate(async () =>
        {
            await _taskService.UpdateOverdueStatusesAsync();
            UpdateTimeRemaining();
        });
    }
    
    private void UpdateTimeRemaining()
    {
        if (DueDate < DateTime.Now)
        {
            TimeRemaining = "Task is overdue.";
        }
        else
        {
            var timeLeft = DueDate - DateTime.Now;
            TimeRemaining = $"{timeLeft.Days}d {timeLeft.Hours}h {timeLeft.Minutes}m remaining";
        }
    }
    
    [RelayCommand]
    private async void ToggleCompleteTask()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
        }
        else
        {
            IsCompleted = false;
        }
        var existingTask = await _taskService.GetTaskByIdAsync(Id);
        if (existingTask != null)
        {
            existingTask.IsCompleted = IsCompleted;
            await _taskService.UpdateTaskAsync(existingTask);
        }
    }
    
    [RelayCommand]
    public async System.Threading.Tasks.Task NavigateToEditTask()
    {
        await Shell.Current.GoToAsync($"{nameof(EditTaskPage)}?Id={Id}");
    }

    [RelayCommand]
    public async void AddExercise()
    {
        await Shell.Current.GoToAsync($"{nameof(AddExercisePage)}?TaskId={Id}");
    }
}
