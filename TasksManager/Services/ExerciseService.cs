namespace TasksManager.Services;

public class ExerciseService
{
    public async System.Threading.Tasks.Task<List<TasksManager.Models.Exercise>> GetExercisesAsync()
    {
        return await App.ExerciseRepository.GetExercisesAsync();
    }

    public async System.Threading.Tasks.Task<TasksManager.Models.Exercise> GetExerciseByIdAsync(int id)
    {
        return await App.ExerciseRepository.GetExerciseByIdAsync(id);
    }
    
    public async System.Threading.Tasks.Task<int> AddExerciseAsync(TasksManager.Models.Exercise exercise)
    {
        return await App.ExerciseRepository.AddExerciseAsync(exercise);
    }

    public async System.Threading.Tasks.Task<int> UpdateExerciseAsync(TasksManager.Models.Exercise exercise)
    {
        return await App.ExerciseRepository.UpdateExerciseAsync(exercise);
    }
    
    // public async System.Threading.Tasks.Task<int> UpdateExerciseAsync(int id)
    // {
    //     var exercise = await App.ExerciseRepository.GetExerciseByIdAsync(id);
    //     if (exercise != null)
    //     {
    //         return await App.ExerciseRepository.UpdateExerciseAsync(exercise);
    //     }
    //     return -1;
    // }

    public async System.Threading.Tasks.Task<int> DeleteExerciseAsync(TasksManager.Models.Exercise exercise)
    {
        return await App.ExerciseRepository.DeleteExerciseAsync(exercise);
    }
    public async System.Threading.Tasks.Task<int> DeleteExerciseAsync(int id)
    {
        var exercise = await App.ExerciseRepository.GetExerciseByIdAsync(id);
        if (exercise != null)
        {
            return await App.ExerciseRepository.DeleteExerciseAsync(exercise);
        }

        return -1;
    }
    
    //new
    public async System.Threading.Tasks.Task<int> DeleteCompletedExercisesAsync()
    {
        return await App.ExerciseRepository.DeleteCompletedExercisesAsync();
    }

    public async System.Threading.Tasks.Task UpdateExpiredStatusesAsync()
    {
        await App.ExerciseRepository.UpdateExpiredStatusesAsync();
    }
    

}