using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels;

namespace TasksManager.Views;

public partial class CurrentTasksPage : ContentPage
{
    public CurrentTasksPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ((TaskListViewModel)BindingContext).RefreshTasks();
    }
}