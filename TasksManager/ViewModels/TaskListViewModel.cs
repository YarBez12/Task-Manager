using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
// using TasksManager.Models;
using TasksManager.Services;
using TasksManager.Views;
// using Task = System.Threading.Tasks.Task;

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
        // var tasksFromRepo = _taskService.GetTasks();
        // var tasks = new ObservableCollection<TaskViewModel>(
        //     tasksFromRepo.Select(task => new TaskViewModel(task))
        // );
        // CurrentTasks = new ObservableCollection<TaskViewModel>(tasks.Where(t => !t.IsCompleted));
        // CompletedTasks = new ObservableCollection<TaskViewModel>(tasks.Where(t => t.IsCompleted));
        CurrentTasks = new ObservableCollection<TaskViewModel>();
        CompletedTasks = new ObservableCollection<TaskViewModel>();
        LoadTasksAsync();
    }

    public async Task LoadTasksAsync()
    {
        var tasksFromRepo = await _taskService.GetTasksAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            foreach (var task in CurrentTasks)
            {
                CurrentTasks.Remove(task);
            }
            foreach (var task in CompletedTasks)
            {
                CompletedTasks.Remove(task);
            }
            // CurrentTasks.Clear();
            // CompletedTasks.Clear();

            var tasks = tasksFromRepo.Select(task => new TaskViewModel(task)).ToList();

            foreach (var task in tasks.Where(t => !t.IsCompleted))
            {
                CurrentTasks.Add(task);
            }

            foreach (var task in tasks.Where(t => t.IsCompleted))
            {
                CompletedTasks.Add(task);
            }
        });
        
    }

    [ObservableProperty]
    private TaskViewModel selectedTask;

    [RelayCommand]
    private async System.Threading.Tasks.Task DeleteTaskAsync(TaskViewModel task)
    {
        if (task != null)
        {
            var result = await _taskService.DeleteTaskAsync(task.Id);
            // await _taskService.DeleteTaskAsync(task.Id);
            // _taskService.DeleteTask(task.Id);
                 // Tasks.Remove(task);
            // CurrentTasks.Remove(task); 
            // CompletedTasks.Remove(task);
                    // if (CurrentTasks.Contains(task))
                    //     CurrentTasks.Remove(task);
                    // if (CompletedTasks.Contains(task))
                    //     CompletedTasks.Remove(task);
            if (result > 0) 
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (CurrentTasks.Contains(task))
                        CurrentTasks.Remove(task);

                    if (CompletedTasks.Contains(task))
                        CompletedTasks.Remove(task);
                });
            }
        }
    }
    
    [RelayCommand]
    private async System.Threading.Tasks.Task CompleteTask(TaskViewModel task)
    {
        if (task != null)
        {
            task.IsCompleted = true;
            var existingTask = await _taskService.GetTaskByIdAsync(task.Id);
            if (existingTask != null)
            {
                existingTask.IsCompleted = true;
                await _taskService.UpdateTaskAsync(existingTask);
                // CurrentTasks.Remove(task); //
                // CompletedTasks.Add(task); //
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (CurrentTasks.Contains(task))
                        CurrentTasks.Remove(task);
                    if (!CompletedTasks.Contains(task))
                        CompletedTasks.Add(task);
                });
            }
            // OnPropertyChanged(nameof(CurrentTasks));
            // OnPropertyChanged(nameof(CompletedTasks));
        }
    }
    
    [RelayCommand]
    private async System.Threading.Tasks.Task DeleteCompletedTasks()
    {
        await _taskService.DeleteCompletedTasksAsync();
        CompletedTasks.Clear();
    }

    [RelayCommand]
    private async System.Threading.Tasks.Task AddTask(TaskViewModel taskViewModel)
    {
        if (taskViewModel != null)
        {
            var newTask = new TasksManager.Models.Task
            {
                // Id = taskViewModel.Id,
                Title = taskViewModel.Title,
                Description = taskViewModel.Description,
                DueDate = taskViewModel.DueDate,
                Priority = taskViewModel.Priority,
                IsCompleted = taskViewModel.IsCompleted
            };

            await _taskService.AddTaskAsync(newTask);
                // Tasks.Add(new TaskViewModel(newTask));
                CurrentTasks.Add(new TaskViewModel(newTask));
        }
    }

    [RelayCommand]
    private async System.Threading.Tasks.Task NavigateToAddTask()
    {
        await Shell.Current.GoToAsync(nameof(AddTaskPage));
    }
    
    [RelayCommand]
    public async System.Threading.Tasks.Task NavigateToEditTask(TaskViewModel task)
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
    
    // public async Task RefreshTasksAsync()
    // {
    //     var tasksFromRepo = await _taskService.GetTasksAsync();
    //     SyncCollection(CurrentTasks, tasksFromRepo.Where(t => !t.IsCompleted));
    //     SyncCollection(CompletedTasks, tasksFromRepo.Where(t => t.IsCompleted));
    // }
    
    public async System.Threading.Tasks.Task RefreshTasksAsync()
    {
        var tasksFromRepo = await _taskService.GetTasksAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            SyncCollection(CurrentTasks, tasksFromRepo.Where(task => !task.IsCompleted));
            SyncCollection(CompletedTasks, tasksFromRepo.Where(task => task.IsCompleted));
        });
    }


    // private void SyncCollection(ObservableCollection<TaskViewModel> targetCollection, IEnumerable<Models.Task> sourceCollection)
    // {
    //     var sourceViewModels = sourceCollection.Select(task => new TaskViewModel(task)).ToList();
    //     for (int i = targetCollection.Count - 1; i >= 0; i--)
    //     {
    //         var existingItem = targetCollection[i];
    //         if (!sourceViewModels.Any(s => s.Id == existingItem.Id))
    //         {
    //             targetCollection.Remove(existingItem);
    //         }
    //     }
    //     foreach (var sourceItem in sourceViewModels)
    //     {
    //         var existingItem = targetCollection.FirstOrDefault(t => t.Id == sourceItem.Id);
    //         if (existingItem == null)
    //         {
    //             targetCollection.Add(sourceItem);
    //         }
    //         else
    //         {
    //             existingItem.Title = sourceItem.Title;
    //             existingItem.Description = sourceItem.Description;
    //             existingItem.DueDate = sourceItem.DueDate;
    //             existingItem.Priority = sourceItem.Priority;
    //             existingItem.IsCompleted = sourceItem.IsCompleted;
    //         }
    //     }
    // }
    
    private void SyncCollection(ObservableCollection<TaskViewModel> targetCollection, IEnumerable<Models.Task> sourceCollection)
    {
        var sourceTasks = sourceCollection.Select(task => new TaskViewModel(task)).ToList();

        // Удаляем элементы, отсутствующие в источнике
        for (int i = targetCollection.Count - 1; i >= 0; i--)
        {
            var item = targetCollection[i];
            if (!sourceTasks.Any(t => t.Id == item.Id))
            {
                targetCollection.Remove(item);
            }
        }

        // Добавляем или обновляем элементы
        foreach (var sourceTask in sourceTasks)
        {
            var existingItem = targetCollection.FirstOrDefault(t => t.Id == sourceTask.Id);
            if (existingItem == null)
            {
                targetCollection.Add(sourceTask); // Добавляем новые
            }
            else
            {
                // Обновляем существующие
                existingItem.Title = sourceTask.Title;
                existingItem.Description = sourceTask.Description;
                existingItem.DueDate = sourceTask.DueDate;
                existingItem.Priority = sourceTask.Priority;
                existingItem.IsCompleted = sourceTask.IsCompleted;
            }
        }
    }


    
    [RelayCommand]
    private async System.Threading.Tasks.Task UnfinishTask(TaskViewModel task)
    {
        if (task != null)
        {
            task.IsCompleted = false;
            var existingTask = await _taskService.GetTaskByIdAsync(task.Id);
            // if (CompletedTasks.Contains(task))
            // {
            //     CompletedTasks.Remove(task);
            //     CurrentTasks.Add(task);
            // }
            // var existingTask = _taskService.GetTaskById(task.Id);
            if (existingTask != null)
            {
                existingTask.IsCompleted = false;
                await _taskService.UpdateTaskAsync(existingTask);
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    CompletedTasks.Remove(task);
                    CurrentTasks.Add(task);
                });
            }
            // RefreshTasks();
        }
    }
    
}