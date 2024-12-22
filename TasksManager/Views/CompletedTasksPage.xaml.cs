using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels;

namespace TasksManager.Views;

public partial class CompletedTasksPage : ContentPage
{
    public CompletedTasksPage()
    {
        InitializeComponent();
        
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ((TaskListViewModel)BindingContext).LoadTasksAsync();
    }
}