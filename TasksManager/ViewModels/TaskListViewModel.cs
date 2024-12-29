using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;
using TasksManager.Services;
using TasksManager.Views;
using Task = System.Threading.Tasks.Task;

namespace TasksManager.ViewModels;

public partial class TaskListViewModel : ObservableObject
{
    public SelectionItemListViewModel<TaskCategory> CategoryList { get; }
    public SelectionItemListViewModel<TaskOverdueStatus> OverdueStatusList { get; }
    [ObservableProperty]
    private List<TaskCategory>? selectedCategories;
    [ObservableProperty]
    private List<TaskOverdueStatus> selectedOverdueStatuses;

    [ObservableProperty]
    private string selectedSortOption;

    public List<string> SortOptions { get; } = new List<string>
    {
        "Alphabetically",
        "By Due Date",
        "By Priority",
    };
    
    // [RelayCommand]
    // private async System.Threading.Tasks.Task SetCategoryFilter(TaskCategory? category)
    // {
    //     SelectedCategory = category;
    //     await LoadTasksAsync();
    // }
    
    private readonly TaskService _taskService;
    private Timer _overdueUpdateTimer;

    [ObservableProperty] 
    private ObservableCollection<TaskViewModel> currentTasks;

    [ObservableProperty] 
    private ObservableCollection<TaskViewModel> completedTasks;
    
    public TaskListViewModel()
    {
        CategoryList = new SelectionItemListViewModel<TaskCategory>();
        SelectedCategories = CategoryList.GetSelectedItems();
        OverdueStatusList = new SelectionItemListViewModel<TaskOverdueStatus>();
        SelectedOverdueStatuses = OverdueStatusList.GetSelectedItems();
        _taskService = new TaskService();
        CurrentTasks = new ObservableCollection<TaskViewModel>();
        CompletedTasks = new ObservableCollection<TaskViewModel>();
        StartOverdueStatusUpdater();
        OnSelectedSortOptionChanged(SelectedSortOption);
    }
    
    private void StartOverdueStatusUpdater()
    {
        ScheduleDailyUpdate(async () =>
        {
            await _taskService.UpdateOverdueStatusesAsync();
            await LoadTasksAsync();
        });
    }
    
    private void ScheduleDailyUpdate(Action action)
    {
        var now = DateTime.Now;
        var midnight = now.Date.AddDays(1);
        var timeUntilMidnight = midnight - now;
        Timer timer = null;
        timer = new Timer(_ =>
        {
            action.Invoke();
            timer?.Dispose();
            ScheduleDailyUpdate(action);
        }, null, timeUntilMidnight, Timeout.InfiniteTimeSpan);
    }
    partial void OnSelectedSortOptionChanged(string value)
    {
        LoadTasksAsync();
    }
    
    // public ObservableCollection<TaskCategory> Categories { get; } =
    //     new ObservableCollection<TaskCategory>((TaskCategory[])Enum.GetValues(typeof(TaskCategory)));
    
    public async Task LoadTasksAsync()
    {
        SelectedSortOption = SelectedSortOption ?? "Alphabetically";
        var tasksFromRepo = await _taskService.GetTasksAsync();
        var filteredTasks = SelectedCategories != null 
            ? tasksFromRepo.Where(t => SelectedCategories.Contains(t.Category))
            : tasksFromRepo;
        filteredTasks = SelectedCategories != null 
            ? filteredTasks.Where(t => SelectedOverdueStatuses.Contains(t.OverdueStatus))
            : filteredTasks;
        var sortedTasks = SelectedSortOption switch
        {
            "Alphabetically" => filteredTasks.OrderBy(t => t.Title),
            "By Due Date" => filteredTasks.OrderBy(t => t.DueDate),
            "By Priority" => filteredTasks.OrderBy(t => t.Priority),
            // _ => filteredTasks
        };
        
        MainThread.BeginInvokeOnMainThread(() =>
        {
            // foreach (var task in CurrentTasks)
            // {
            //     CurrentTasks.Remove(task);
            // }
            //
            // foreach (var task in CompletedTasks)
            // {
            //     CompletedTasks.Remove(task);
            // }
            CurrentTasks.Clear();
            CompletedTasks.Clear();

            var tasks = sortedTasks.Select(task => new TaskViewModel(task)).ToList();

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
    // public async System.Threading.Tasks.Task RefreshTasksAsync()
    // {
    //     var tasksFromRepo = await _taskService.GetTasksAsync();
    //     MainThread.BeginInvokeOnMainThread(() =>
    //     {
    //         SyncCollection(CurrentTasks, tasksFromRepo.Where(task => !task.IsCompleted));
    //         SyncCollection(CompletedTasks, tasksFromRepo.Where(task => task.IsCompleted));
    //     });
    // }


    
    // private void SyncCollection(ObservableCollection<TaskViewModel> targetCollection, IEnumerable<Models.Task> sourceCollection)
    // {
    //     var sourceTasks = sourceCollection.Select(task => new TaskViewModel(task)).ToList();
    //
    //     for (int i = targetCollection.Count - 1; i >= 0; i--)
    //     {
    //         var item = targetCollection[i];
    //         if (!sourceTasks.Any(t => t.Id == item.Id))
    //         {
    //             targetCollection.Remove(item);
    //         }
    //     }
    //
    //     foreach (var sourceTask in sourceTasks)
    //     {
    //         var existingItem = targetCollection.FirstOrDefault(t => t.Id == sourceTask.Id);
    //         if (existingItem == null)
    //         {
    //             targetCollection.Add(sourceTask); 
    //         }
    //         else
    //         {
    //             existingItem.Title = sourceTask.Title;
    //             existingItem.Description = sourceTask.Description;
    //             existingItem.DueDate = sourceTask.DueDate;
    //             existingItem.Priority = sourceTask.Priority;
    //             existingItem.Category = sourceTask.Category;
    //             existingItem.IsCompleted = sourceTask.IsCompleted;
    //         }
    //     }
    // }

    [ObservableProperty]
    private TaskViewModel selectedTask;

    [RelayCommand]
    private async System.Threading.Tasks.Task DeleteTaskAsync(TaskViewModel task)
    {
        if (task != null)
        {
            var result = await _taskService.DeleteTaskAsync(task.Id);
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
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (CurrentTasks.Contains(task))
                        CurrentTasks.Remove(task);
                    if (!CompletedTasks.Contains(task))
                        CompletedTasks.Add(task);
                });
            }
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
                Category = taskViewModel.Category,
                OverdueStatus = taskViewModel.OverdueStatus,
                IsCompleted = taskViewModel.IsCompleted
            };

            await _taskService.AddTaskAsync(newTask);
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
    
    
    
    


    
    [RelayCommand]
    private async System.Threading.Tasks.Task UnfinishTask(TaskViewModel task)
    {
        if (task != null)
        {
            task.IsCompleted = false;
            var existingTask = await _taskService.GetTaskByIdAsync(task.Id);
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
        }
    }

    [RelayCommand]
    private async System.Threading.Tasks.Task ShowCategorySelection()
    {
        var popup = new CategorySelectionPopup();
        popup.BindingContext = CategoryList;
        var result = await Application.Current?.MainPage?.ShowPopupAsync(popup);
        if (result is bool isOk && isOk)
        {
            SelectedCategories = CategoryList.GetSelectedItems();
            await LoadTasksAsync();
        }
    }
    
    [RelayCommand]
    private async System.Threading.Tasks.Task ShowOverdueSelection()
    {
        var popup = new OverdueSelectionPopup();
        popup.BindingContext = OverdueStatusList;
        var result = await Application.Current?.MainPage?.ShowPopupAsync(popup);
        if (result is bool isOk && isOk)
        {
            SelectedOverdueStatuses = OverdueStatusList.GetSelectedItems();
            await LoadTasksAsync();
        }
    }
    
}