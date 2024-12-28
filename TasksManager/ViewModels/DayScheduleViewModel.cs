using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Views;

namespace TasksManager.ViewModels;

public partial class DayScheduleViewModel : ObservableObject
{
    [ObservableProperty]
    private DateTime date;
    
    [ObservableProperty]
    private ObservableCollection<ExerciseViewModel> exercises = new();
    
    [RelayCommand]
    private async System.Threading.Tasks.Task AddExercise(DateTime date)
    {
        await Shell.Current.GoToAsync($"{nameof(AddExercisePage)}?SelectedDate={date:yy-MM-dd}");
    }
}