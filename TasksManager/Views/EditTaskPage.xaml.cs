using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Models;
using TasksManager.ViewModels;
using Task = TasksManager.Models.Task;

namespace TasksManager.Views;

[QueryProperty(nameof(TaskId), "Id")]
public partial class EditTaskPage : ContentPage
{
    private Task task;
    public EditTaskPage()
    {
        InitializeComponent();
    }

    public string TaskId
    {
        set
        {
            task = TaskRepository.GetTaskById(int.Parse(value));
            DisplayAlert("Task",(task == null).ToString(), "OK");
            if (task != null)
            {
                BindingContext = new TaskViewModel(task);
            }
            
        }
    }
}