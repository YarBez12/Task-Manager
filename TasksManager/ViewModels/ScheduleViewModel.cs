using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TasksManager.Models;
using TasksManager.Services;
using TasksManager.Views;

namespace TasksManager.ViewModels;


public partial class ScheduleViewModel : ObservableObject
{
    private readonly ExerciseService _exerciseService;
    private DateTime _currentWeekStart;
    private const int MaxWeeksForward = 2;
    private const int MaxWeeksBackward = 1;

    [ObservableProperty]
    private DateTime selectedWeekStart;

    [ObservableProperty]
    private string displayedWeekRange;

    [ObservableProperty]
    private bool canNavigateToPreviousWeek;

    [ObservableProperty]
    private bool canNavigateToNextWeek;

    [ObservableProperty]
    private ObservableCollection<DayScheduleViewModel> weekSchedule;

    public ScheduleViewModel()
    {
        _exerciseService = new ExerciseService();
        _currentWeekStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        SelectedWeekStart = _currentWeekStart;

        WeekSchedule = new ObservableCollection<DayScheduleViewModel>();
        Update();
    }

    [RelayCommand]
    public void PreviousWeek()
    {
        if (CanNavigateToPreviousWeek)
        {
            SelectedWeekStart = SelectedWeekStart.AddDays(-7);
            Update();
        }
    }

    public async System.Threading.Tasks.Task Update()
    {
        await UpdateDisplayedWeekRange();
        await UpdateNavigationLimits();
        await LoadWeekSchedule();
    }

    [RelayCommand]
    public void NextWeek()
    {
        if (CanNavigateToNextWeek)
        {
            SelectedWeekStart = SelectedWeekStart.AddDays(7);
            Update();
        }
    }

    private async System.Threading.Tasks.Task UpdateDisplayedWeekRange()
    {
        var endOfWeek = SelectedWeekStart.AddDays(6);
        DisplayedWeekRange = $"{SelectedWeekStart:MMMM d, yyyy} - {endOfWeek:MMMM d, yyyy}";
    }

    private async System.Threading.Tasks.Task UpdateNavigationLimits()
    {
        CanNavigateToPreviousWeek = SelectedWeekStart > _currentWeekStart.AddDays(-7 * MaxWeeksBackward);
        CanNavigateToNextWeek = SelectedWeekStart < _currentWeekStart.AddDays(7 * MaxWeeksForward);
    }

    public async System.Threading.Tasks.Task LoadWeekSchedule()
    {
        var exercises = await _exerciseService.GetExercisesAsync();
        WeekSchedule.Clear();

        for (int i = 0; i < 7; i++)
        {
            var currentDay = SelectedWeekStart.AddDays(i);
            var dayExercises = exercises
                .Where(e => e.Date.Date == currentDay)
                .Select(e => new ExerciseViewModel(e))
                .ToList();

            WeekSchedule.Add(new DayScheduleViewModel
            {
                Date = currentDay,
                Exercises = new ObservableCollection<ExerciseViewModel>(dayExercises)
            });
        }
    }
    
    // [RelayCommand]
    // private async System.Threading.Tasks.Task AddExercise()
    // {
    //     await Shell.Current.GoToAsync(nameof(AddExercisePage));
    // }
}
