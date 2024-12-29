using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels;

namespace TasksManager.Views;

[QueryProperty(nameof(TaskId), "Id")]
public partial class TaskDetailPage : ContentPage
{
    private Models.Task task;
    public TaskDetailPage()
    {
        InitializeComponent();
    }
    
    private async System.Threading.Tasks.Task LoadTasksAsync(int taskId)
    {
        var task = await App.TaskRepository.GetTaskByIdAsync(taskId);
        if (task != null)
        {
            BindingContext = new TaskViewModel(task);
        }
    }
    // protected override async void OnAppearing()
    // {
    //     base.OnAppearing();
    //     await ((TaskListViewModel)BindingContext).LoadTasksAsync();
    // }

    public string TaskId
    {
        set
        {
            _ = LoadTasksAsync(int.Parse(value));
        }
    }
}