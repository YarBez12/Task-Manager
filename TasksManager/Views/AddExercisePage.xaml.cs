using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels;

namespace TasksManager.Views;

[QueryProperty(nameof(Date), "SelectedDate")]
public partial class AddExercisePage : ContentPage
{
    public AddExercisePage()
    {
        InitializeComponent();
    }

    public string Date
    {
        set
        {
            if (DateTime.TryParseExact(value, "yy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var parsedDate))
            {
                BindingContext = new ExerciseViewModel()
                {
                    Date = parsedDate
                };
            }
            else
            {
                BindingContext = new ExerciseViewModel()
                {
                    Date = DateTime.Now 
                };
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