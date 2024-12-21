using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;
using TasksManager.Services;
using Task = TasksManager.Models.Task;

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

    public bool IsOverdue => !IsCompleted && DateTime.Now > DueDate;

    public TaskViewModel(int id, string title, string description, DateTime dueDate, TaskPriority priority, TaskService taskService = null)
    {
        _taskService = taskService ?? new TaskService();
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        IsCompleted = false;
    }

    public TaskViewModel(Task task, TaskService taskService = null)
    {
        _taskService = taskService ?? new TaskService();
        Id = task.Id;
        title = task.Title;
        description = task.Description;
        dueDate = task.DueDate;
        priority = task.Priority;
        isCompleted = task.IsCompleted;
    }
    public TaskViewModel(TaskService taskService = null)
    {
        _taskService = taskService ?? new TaskService();
        DueDate = DateTime.Now;
        Priority = TaskPriority.Medium;
    }
    public TaskViewModel()
    {
        _taskService = new TaskService();
        DueDate = DateTime.Now;
        Priority = TaskPriority.Medium;
    }
    
    public ObservableCollection<TaskPriority> Priorities { get; } =
        new ObservableCollection<TaskPriority>((TaskPriority[])Enum.GetValues(typeof(TaskPriority)));
    
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
    public void SaveTask()
    {
        if (Id <= 0)
        {
            var newTask = new Models.Task
            {
                Id = Id,
                Title = Title,
                Description = Description,
                DueDate = DueDate,
                Priority = Priority,
                IsCompleted = IsCompleted
            };

            _taskService.AddTask(newTask); 
            Id = newTask.Id;
        }
        else 
        {
            var existingTask = _taskService.GetTaskById(Id);
            if (existingTask != null)
            {
                existingTask.Id = Id;
                existingTask.Title = Title;
                existingTask.Description = Description;
                existingTask.DueDate = DueDate;
                existingTask.Priority = Priority;
                existingTask.IsCompleted = IsCompleted;

                _taskService.UpdateTask(existingTask); 
            }
        }
        Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public void Cancel()
    {
        Shell.Current.GoToAsync("..");
    }
    
    
}