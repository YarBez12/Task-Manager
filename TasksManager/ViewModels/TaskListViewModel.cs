using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;
using TasksManager.Services;
using TasksManager.Views;
using Task = System.Threading.Tasks.Task;

namespace TasksManager.ViewModels;

public partial class TaskListViewModel : ObservableObject
{
    private readonly TaskService _taskService;
    // public ObservableCollection<TaskViewModel> Tasks { get; set; }

    [ObservableProperty] 
    private ObservableCollection<TaskViewModel> currentTasks;

    [ObservableProperty] 
    private ObservableCollection<TaskViewModel> completedTasks;

    // public TaskListViewModel(TaskService taskService)
    // {
    //     _taskService = taskService;
    //     var tasksFromRepo = taskService.GetTasks();
    //     var tasks = new ObservableCollection<TaskViewModel>(
    //         tasksFromRepo.Select(task => new TaskViewModel(task))
    //     );
    //     CurrentTasks = new ObservableCollection<TaskViewModel>(tasks.Where(t => !t.IsCompleted));
    //     CompletedTasks = new ObservableCollection<TaskViewModel>(tasks.Where(t => t.IsCompleted));
    // }
    
    public TaskListViewModel()
    {
        _taskService = new TaskService();
        var tasksFromRepo = _taskService.GetTasks();
        var tasks = new ObservableCollection<TaskViewModel>(
            tasksFromRepo.Select(task => new TaskViewModel(task))
        );
        CurrentTasks = new ObservableCollection<TaskViewModel>(tasks.Where(t => !t.IsCompleted));
        CompletedTasks = new ObservableCollection<TaskViewModel>(tasks.Where(t => t.IsCompleted));
    }

    [ObservableProperty]
    private TaskViewModel selectedTask;

    [RelayCommand]
    private void DeleteTask(TaskViewModel task)
    {
        if (task != null)
        {
            _taskService.DeleteTask(task.Id);
                 // Tasks.Remove(task);
            // CurrentTasks.Remove(task); 
            // CompletedTasks.Remove(task);
            if (CurrentTasks.Contains(task))
                CurrentTasks.Remove(task);
            if (CompletedTasks.Contains(task))
                CompletedTasks.Remove(task);
        }
    }
    
    [RelayCommand]
    private void CompleteTask(TaskViewModel task)
    {
        if (task != null)
        {
            task.IsCompleted = true;
            var existingTask = TaskRepository.GetTaskById(task.Id);
            if (existingTask != null)
            {
                existingTask.IsCompleted = true;
                TaskRepository.UpdateTask(existingTask);
                // CurrentTasks.Remove(task); //
                // CompletedTasks.Add(task); //
                if (CurrentTasks.Contains(task))
                    CurrentTasks.Remove(task);
                if (!CompletedTasks.Contains(task))
                    CompletedTasks.Add(task);
            }
            // OnPropertyChanged(nameof(CurrentTasks));
            // OnPropertyChanged(nameof(CompletedTasks));
        }
    }
    
    [RelayCommand]
    private void DeleteCompletedTasks()
    {
        // var CompletedTasks = Tasks.Where(task => task.IsCompleted).ToList();
        foreach (var task in CompletedTasks)
        {
            _taskService.DeleteTask(task.Id);
                // Tasks.Remove(task);
        }
        CompletedTasks.Clear();
    }

    [RelayCommand]
    private void AddTask(TaskViewModel taskViewModel)
    {
        if (taskViewModel != null)
        {
            var newTask = new Models.Task
            {
                Id = taskViewModel.Id,
                Title = taskViewModel.Title,
                Description = taskViewModel.Description,
                DueDate = taskViewModel.DueDate,
                Priority = taskViewModel.Priority,
                IsCompleted = taskViewModel.IsCompleted
            };

            _taskService.AddTask(newTask);

                // Tasks.Add(new TaskViewModel(newTask));
            CurrentTasks.Add(new TaskViewModel(newTask));
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
    
    // public void RefreshTasks()
    // {
    //     var tasksFromRepo = _taskService.GetTasks();
    //     MainThread.BeginInvokeOnMainThread(() =>
    //     {
    //             // Tasks.Clear();
    //         // CurrentTasks.Clear();
    //         // CompletedTasks.Clear();
    //         // foreach (var task in tasksFromRepo)
    //         // {
    //         //     var taskViewModel = new TaskViewModel(task);
    //         //         // Tasks.Add(taskViewModel);
    //         //     if (!task.IsCompleted)
    //         //     {
    //         //         CurrentTasks.Add(taskViewModel);
    //         //     }
    //         //     else
    //         //     {
    //         //         CompletedTasks.Add(taskViewModel);
    //         //     }
    //         //
    //         // }
    //         // CurrentTasks.ReplaceRange(tasksFromRepo.Where(t => !t.IsCompleted).Select(task => new TaskViewModel(task)));
    //         // CompletedTasks.ReplaceRange(tasksFromRepo.Where(t => t.IsCompleted).Select(task => new TaskViewModel(task)));
    //                 // var tasks = new ObservableCollection<TaskViewModel>(
    //                 //     tasksFromRepo.Select(task => new TaskViewModel(task))
    //                 // );
    //                 // CurrentTasks = new ObservableCollection<TaskViewModel>(tasks.Where(t => !t.IsCompleted));
    //                 // CompletedTasks = new ObservableCollection<TaskViewModel>(tasks.Where(t => t.IsCompleted));
    //         SyncCollection(CurrentTasks, tasksFromRepo.Where(task => !task.IsCompleted));
    //
    //         // Синхронизация CompletedTasks
    //         SyncCollection(CompletedTasks, tasksFromRepo.Where(task => task.IsCompleted));
    //         // if (currentSelectedTaskId != null)
    //         // {
    //         //     SelectedTask = Tasks.FirstOrDefault(t => t.Id == currentSelectedTaskId);
    //         // }
    //         // OnPropertyChanged(nameof(CurrentTasks));
    //         // OnPropertyChanged(nameof(CompletedTasks));
    //     });
    // }
    
    public void RefreshTasks()
    {
        var tasksFromRepo = _taskService.GetTasks();
        SyncCollection(CurrentTasks, tasksFromRepo.Where(t => !t.IsCompleted));
        SyncCollection(CompletedTasks, tasksFromRepo.Where(t => t.IsCompleted));
    }

    private void SyncCollection(ObservableCollection<TaskViewModel> targetCollection, IEnumerable<Models.Task> sourceCollection)
    {
        var sourceViewModels = sourceCollection.Select(task => new TaskViewModel(task)).ToList();
        for (int i = targetCollection.Count - 1; i >= 0; i--)
        {
            var existingItem = targetCollection[i];
            if (!sourceViewModels.Any(s => s.Id == existingItem.Id))
            {
                targetCollection.Remove(existingItem);
            }
        }
        foreach (var sourceItem in sourceViewModels)
        {
            var existingItem = targetCollection.FirstOrDefault(t => t.Id == sourceItem.Id);
            if (existingItem == null)
            {
                targetCollection.Add(sourceItem);
            }
            else
            {
                existingItem.Title = sourceItem.Title;
                existingItem.Description = sourceItem.Description;
                existingItem.DueDate = sourceItem.DueDate;
                existingItem.Priority = sourceItem.Priority;
                existingItem.IsCompleted = sourceItem.IsCompleted;
            }
        }
    }
    
    [RelayCommand]
    private void UnfinishTask(TaskViewModel task)
    {
        if (task != null)
        {
            task.IsCompleted = false;
            if (CompletedTasks.Contains(task))
            {
                CompletedTasks.Remove(task);
                CurrentTasks.Add(task);
            }
            var existingTask = _taskService.GetTaskById(task.Id);
            if (existingTask != null)
            {
                existingTask.IsCompleted = false;
                _taskService.UpdateTask(existingTask);
            }
            // RefreshTasks();
        }
    }
    
}