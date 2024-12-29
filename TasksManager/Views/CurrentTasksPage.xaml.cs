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
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ((TaskListViewModel)BindingContext).LoadTasksAsync();
    }

    private void ListView_OnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        if (e.Item is TaskViewModel task)
        {
            var viewModel = BindingContext as TaskListViewModel;
            if (viewModel?.NavigateToDetailPageCommand.CanExecute(task) == true)
            {
                viewModel.NavigateToDetailPageCommand.Execute(task);
            }
        }
        ((ListView)sender).SelectedItem = null;
    }
}