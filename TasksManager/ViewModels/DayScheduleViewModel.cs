using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;
using TasksManager.Services;
using TasksManager.Views;

namespace TasksManager.ViewModels;

public partial class DayScheduleViewModel : ObservableObject
{
    private ExerciseService _exerciseService = new ExerciseService();
    private TaskService _taskService = new TaskService();
    [ObservableProperty]
    private DateTime date;
    private Timer _overdueUpdateTimer;

    [ObservableProperty] 
    private bool isNotPast = false;
    
    [ObservableProperty]
    private ObservableCollection<ExerciseViewModel> exercises = new();
    
    [RelayCommand]
    private async System.Threading.Tasks.Task AddExercise(DateTime date)
    {
        await Shell.Current.GoToAsync($"{nameof(AddExercisePage)}?SelectedDate={date:yy-MM-dd}");
    }

    [RelayCommand]
    private async System.Threading.Tasks.Task EditExercise(ExerciseViewModel exercise)
    {
        await Shell.Current.GoToAsync($"{nameof(EditExercisePage)}?Id={exercise.Id}");
    }

    [RelayCommand]
    private async System.Threading.Tasks.Task DeleteExercise(ExerciseViewModel exercise)
    {
        if (exercise != null)
        {
            var result = await _exerciseService.DeleteExerciseAsync(exercise.Id);
            if (result > 0)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Exercises.Remove(exercise);
                });
            }
        }
    }

    [RelayCommand]
    private void MoveUp(ExerciseViewModel exercise)
    {
        var index = Exercises.IndexOf(exercise);
        if (index > 0)
        {
            Exercises.Move(index, index - 1);
            var z = Exercises;
            UpdatePriorities();
        }
    }
    
    [RelayCommand]
    private void MoveDown(ExerciseViewModel exercise)
    {
        var index = Exercises.IndexOf(exercise);
        if (index < Exercises.Count - 1)
        {
            Exercises.Move(index, index + 1);
            var z = Exercises;
            UpdatePriorities();
        }
    }
    

    private void UpdatePriorities()
    {
        for (int i = 0; i < Exercises.Count; i++)
        {
            Exercises[i].Priority = i + 1;
        }
        SavePriorities();
    }

    private async void SavePriorities()
    {
        foreach (var ex in Exercises)
        {
            var exercise = await _exerciseService.GetExerciseByIdAsync(ex.Id);
            if (exercise != null)
            {
                exercise.Priority = ex.Priority;
                await _exerciseService.UpdateExerciseAsync(exercise);
            }
        }
    }

    [RelayCommand]
    private async System.Threading.Tasks.Task ToggleExerciseCompletedStatus(ExerciseViewModel exercise)
    {
        var allExercises = await _exerciseService.GetExercisesAsync();
        if (exercise != null)
        {
            if (!exercise.IsCompleted)
            {
                if (exercise.IsLast)
                {
                    if (allExercises.Any(e => !e.IsCompleted && e.TaskId == exercise.TaskId && e.Id != exercise.Id))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error",
                            "Can not finish last exercise when there are some other unfinished exercises for this task",
                            "OK");
                        return;
                    }
                    var connectedTask = await _taskService.GetTaskByIdAsync(exercise.TaskId);
                    connectedTask.IsCompleted = true;
                    await _taskService.UpdateTaskAsync(connectedTask);
                }
                exercise.IsCompleted = true;
            }
            else
            {
                if (exercise.Date < DateTime.Now.Date)
                {
                    exercise.IsExpired = true;
                }
                exercise.IsCompleted = false;
                var x = allExercises.Where(e => (e.IsCompleted && e.TaskId == exercise.TaskId) || e.Id == exercise.Id);
                if (allExercises.Where(e => e.TaskId == exercise.TaskId).All(e => e.IsCompleted || e.Id == exercise.Id))
                {
                    foreach (var ex in allExercises.Where(e =>  e.TaskId == exercise.TaskId))
                    {
                        ex.IsLast = false;
                        await _exerciseService.UpdateExerciseAsync(ex);
                    }
                    exercise.IsLast = true;
                    var connectedTask = await _taskService.GetTaskByIdAsync(exercise.TaskId);
                    connectedTask.IsCompleted = false;
                    await _taskService.UpdateTaskAsync(connectedTask);
                }

                // var xx = exercise.Date;
                // var y = DateTime.Now.Date;
                
            }
            var existingExercise = await _exerciseService.GetExerciseByIdAsync(exercise.Id);
            if (existingExercise != null)
            {
                existingExercise.IsCompleted = exercise.IsCompleted;
                existingExercise.IsLast = exercise.IsLast;
                existingExercise.IsExpired = exercise.IsExpired;
                await _exerciseService.UpdateExerciseAsync(existingExercise);
            }
        }
    }
}