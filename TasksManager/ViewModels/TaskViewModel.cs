using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;
using TasksManager.Services;
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
    private TaskCategory category;
    
    [ObservableProperty]
    private TaskOverdueStatus isOverdue;

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

    public TaskViewModel(TasksManager.Models.Task task, TaskService taskService = null)
    {
        _taskService = taskService ?? new TaskService();
        Id = task.Id;
        title = task.Title;
        description = task.Description;
        dueDate = task.DueDate;
        priority = task.Priority;
        category = task.Category;
        isOverdue = task.IsOverdue;
        isCompleted = task.IsCompleted;
    }
    public TaskViewModel(TaskService taskService = null)
    {
        _taskService = taskService ?? new TaskService();
        DueDate = DateTime.Now;
        Priority = TaskPriority.Medium;
        isOverdue = TaskOverdueStatus.NotOverdue;
        Category = TaskCategory.Work;
    }
    public TaskViewModel()
    {
        _taskService = new TaskService();
        DueDate = DateTime.Now;
        Priority = TaskPriority.Medium;
        isOverdue = TaskOverdueStatus.NotOverdue;
        Category = TaskCategory.Work;
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
                IsOverdue = IsOverdue,
                IsCompleted = IsCompleted
            };

            Id = await _taskService.AddTaskAsync(newTask);
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
                existingTask.IsOverdue = IsOverdue;

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
    
    
}