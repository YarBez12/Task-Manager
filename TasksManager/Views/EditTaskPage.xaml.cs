using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Models;
using TasksManager.ViewModels;
// using Task = TasksManager.Models.Task;

namespace TasksManager.Views;

[QueryProperty(nameof(TaskId), "Id")]
public partial class EditTaskPage : ContentPage
{
    private TasksManager.Models.Task task;
    public EditTaskPage()
    {
        InitializeComponent();
    }

    public string TaskId
    {
        set
        {
            // task = TaskRepository.GetTaskById(int.Parse(value));
            // DisplayAlert("Task",(task == null).ToString(), "OK");
            // if (task != null)
            // {
            //     BindingContext = new TaskViewModel(task);
            // }
            // DisplayAlert("Edit Task", value, "OK");
            // var tasks = await App.TaskRepository.GetTasksAsync();
            // foreach (var t in tasks)
            // {
            //     DisplayAlert("Task", t.Id.ToString(), "OK");
            // }
            _ = LoadTaskAsync(int.Parse(value));
            
        }
    }
    
    private async System.Threading.Tasks.Task LoadTaskAsync(int taskId)
    {
        // DisplayAlert("Task Loaded", taskId.ToString(), "OK");
        // var tasks = await App.TaskRepository.GetTasksAsync();
        // foreach (var t in tasks)
        // {
        //     DisplayAlert("Task", t.Id.ToString(), "OK");
        // }
        var task = await App.TaskRepository.GetTaskByIdAsync(taskId);
        // DisplayAlert("Task Loaded", taskId.ToString(), "OK");
        if (task != null)
        {
            BindingContext = new TaskViewModel(task);
        }
    }
}


