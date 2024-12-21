using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;
using TasksManager.Views;
using Task = System.Threading.Tasks.Task;

namespace TasksManager.ViewModels;

public partial class TaskListViewModel : ObservableObject
{
    public ObservableCollection<TaskViewModel> Tasks { get; set; } = new ObservableCollection<TaskViewModel>();

    public TaskListViewModel()
    {
        var tasksFromRepo = TaskRepository.GetTasks();
        Tasks = new ObservableCollection<TaskViewModel>(
            tasksFromRepo.Select(task => new TaskViewModel(
                task.Id,
                task.Title,
                task.Description,
                task.DueDate,
                task.Priority)
            {
                IsCompleted = task.IsCompleted,
                Id = task.Id
            })
        );
    }

    [ObservableProperty]
    private TaskViewModel selectedTask;

    [RelayCommand]
    private void DeleteTask(TaskViewModel task)
    {
        if (task != null)
        {
            Tasks.Remove(task);
        }
    }
    
    [RelayCommand]
    private void CompleteTask(TaskViewModel task)
    {
        if (task != null)
        {
            task.IsCompleted = true;
        }
    }
    
    [RelayCommand]
    private void DeleteCompletedTasks()
    {
        var CompletedTasks = Tasks.Where(task => task.IsCompleted).ToList();
        foreach (var task in CompletedTasks)
        {
            Tasks.Remove(task);
        }
    }

    [RelayCommand]
    private void AddTask(TaskViewModel task)
    {
        if (task != null)
        {
            var newTask = new Models.Task
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                IsCompleted = task.IsCompleted
            };

            TaskRepository.AddTask(newTask);

            Tasks.Add(new TaskViewModel(newTask));
        }
    }

    [RelayCommand]
    private async Task NavigateToAddTask()
    {
        await Shell.Current.GoToAsync(nameof(AddTaskPage));
    }
    
    [RelayCommand]
    public async Task NavigateToEditTask(TaskViewModel task)
    {
        if (task != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditTaskPage)}?Id={task.Id}");
        }
    }
    
    public void RefreshTasks()
    {
        var tasksFromRepo = TaskRepository.GetTasks();
        var currentSelectedTaskId = SelectedTask?.Id; 

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Tasks.Clear();
            foreach (var task in tasksFromRepo)
            {
                Tasks.Add(new TaskViewModel(task));
            }
            if (currentSelectedTaskId != null)
            {
                SelectedTask = Tasks.FirstOrDefault(t => t.Id == currentSelectedTaskId);
            }
        });
    }
    
}