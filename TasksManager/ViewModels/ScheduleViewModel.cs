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
        StartStatusUpdater();
        Update();
    }
    
    // private void StartWeekStatusUpdater()
    // {
    //     _weekUpdateTimer = new Timer(async _ =>
    //     {
    //         _currentWeekStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
    //         await Update();
    //     }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
    // }
    //
    // private void StartOverdueStatusUpdater()
    // {
    //     _overdueUpdateTimer = new Timer(async _ =>
    //     {
    //         await _exerciseService.UpdateExpiredStatusesAsync();
    //         await Update();
    //     }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
    // }
    
    private void StartStatusUpdater()
    {
        ScheduleDailyUpdate(async () =>
        {
            _currentWeekStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            await _exerciseService.UpdateExpiredStatusesAsync();
            await Update();
        });
    }

    // private void StartOverdueStatusUpdater()
    // {
    //     ScheduleDailyUpdate(() =>
    //     {
    //         _exerciseService.UpdateExpiredStatusesAsync().Wait();
    //         Update().Wait();
    //     });
    // }
    
    private void ScheduleDailyUpdate(Action action)
    {
        var now = DateTime.Now;
        var midnight = now.Date.AddDays(1);
        var timeUntilMidnight = midnight - now;
        Timer timer = null;
        timer = new Timer(_ =>
        {
            action.Invoke();
            timer?.Dispose();
            ScheduleDailyUpdate(action);
        }, null, timeUntilMidnight, Timeout.InfiniteTimeSpan);
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
                .Where(e => e.Date.Date == currentDay.Date)
                .Select(e => new ExerciseViewModel(e))
                .OrderBy(e => e.Priority)
                .ToList();
            foreach (ExerciseViewModel exercise in dayExercises)
            {
                if (exercise.IsCompleted)
                {
                    exercise.IsNotCompleted = false;
                    exercise.UpdateButtonText = "↩️";
                    exercise.BgColor = Color.FromArgb("#9ACD32");
                }
                else if (exercise.IsExpired)
                {
                    exercise.IsNotCompleted = true;
                    exercise.UpdateButtonText = "\u2714\ufe0f";
                    exercise.BgColor = Color.FromArgb("#FFB6C1");
                }
                else
                {
                    exercise.IsNotCompleted = true;
                    exercise.UpdateButtonText = "\u2714\ufe0f";
                    exercise.BgColor = Color.FromArgb("#FFA500");
                }
            }

            WeekSchedule.Add(new DayScheduleViewModel
            {
                Date = currentDay,
                Exercises = new ObservableCollection<ExerciseViewModel>(dayExercises),
                IsNotPast = currentDay >= DateTime.Now.Date
            });
        }
    }
    
    
    
    // [RelayCommand]
    // private async System.Threading.Tasks.Task AddExercise()
    // {
    //     await Shell.Current.GoToAsync(nameof(AddExercisePage));
    // }
}
