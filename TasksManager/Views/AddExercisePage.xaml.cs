using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels;

namespace TasksManager.Views;

[QueryProperty(nameof(Date), "SelectedDate")]
[QueryProperty(nameof(TaskId), "TaskId")]
public partial class AddExercisePage : ContentPage
{
    private string _date;
    private string _taskId;
    public AddExercisePage()
    {
        InitializeComponent();
    }

    public string Date
    {
        set
        {
            _date = value;
            InitializeBindingContext();
            // if (DateTime.TryParseExact(value, "yy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var parsedDate))
            // {
            //     BindingContext = new ExerciseViewModel()
            //     {
            //         Date = parsedDate
            //     };
            // }
            // else
            // {
            //     BindingContext = new ExerciseViewModel()
            //     {
            //         Date = DateTime.Now.Date,
            //         IsDateNotSet = true
            //     };
            // }
        }
    }
    public string TaskId
    {
        set
        {
            _taskId = value;
            InitializeBindingContext();
            // if (int.TryParse(value, out var parsedTaskId))
            // {
            //     ((ExerciseViewModel)BindingContext).TaskId = parsedTaskId;
            //     ((ExerciseViewModel)BindingContext).IsTaskFieldEnabled = false;
            // }
        }
    }
    
    private void InitializeBindingContext()
    {
        if (BindingContext == null)
        {
            BindingContext = new ExerciseViewModel();
        }

        if (BindingContext is ExerciseViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(_date) &&
                DateTime.TryParseExact(_date, "yy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var parsedDate))
            {
                viewModel.Date = parsedDate;
            }
            else if (string.IsNullOrEmpty(_date))
            {
                viewModel.Date = DateTime.Now.Date;
                viewModel.IsDateNotSet = true; 
            }
            if (!string.IsNullOrEmpty(_taskId) && int.TryParse(_taskId, out var parsedTaskId))
            {
                viewModel.TaskId = parsedTaskId;
                viewModel.IsTaskFieldEnabled = false;
            }
        }
    }
    
    // protected override void OnAppearing()
    // {
    //     base.OnAppearing();
    //
    //     if (BindingContext is ExerciseViewModel viewModel &&
    //         Shell.Current?.CurrentState?.QueryProperties.TryGetValue("SelectedDate", out string dateString) &&
    //         DateTime.TryParse(dateString, out DateTime selectedDate))
    //     {
    //         viewModel.Initialize(selectedDate);
    //     }
    // }

}