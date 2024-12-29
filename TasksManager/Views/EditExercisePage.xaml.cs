using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Models;
using TasksManager.ViewModels;

namespace TasksManager.Views;

[QueryProperty(nameof(ExerciseId), "Id")]
public partial class EditExercisePage : ContentPage
{
    private Exercise exercise;
    public EditExercisePage()
    {
        InitializeComponent();
    }

    private async System.Threading.Tasks.Task LoadExercisesAsync(int exerciseId)
    {
        var exercise = await App.ExerciseRepository.GetExerciseByIdAsync(exerciseId);
        if (exercise != null)
        {
            BindingContext = new ExerciseViewModel(exercise);
        }
    }

    public string ExerciseId
    {
        set
        {
            _ = LoadExercisesAsync(int.Parse(value));
        }
    }
}