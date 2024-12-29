using SQLite;


namespace TasksManager.Models;
public class ExerciseRepository
{
    string _dbPath;
    private SQLiteAsyncConnection conn;

    public ExerciseRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    private async System.Threading.Tasks.Task InitAsync()
    {
        if (conn != null)
            return;
        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<TasksManager.Models.Exercise>();
    }
    
    public async System.Threading.Tasks.Task<List<TasksManager.Models.Exercise>> GetExercisesAsync()
    {
        await InitAsync();
        return await conn.Table<TasksManager.Models.Exercise>().ToListAsync();
    }

    public async System.Threading.Tasks.Task<TasksManager.Models.Exercise> GetExerciseByIdAsync(int id)
    {
        await InitAsync();
        return await conn.Table<TasksManager.Models.Exercise>().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async System.Threading.Tasks.Task<int> AddExerciseAsync(TasksManager.Models.Exercise exercise)
    {
        await InitAsync();
        var exercisesOnSameDate = await conn.Table<Exercise>().Where(e => e.Date == exercise.Date).ToListAsync();
        foreach (var existingExercise in exercisesOnSameDate)
        {
            existingExercise.Priority += 1;
            await conn.UpdateAsync(existingExercise);
        }
        exercise.Priority = 1;
        return await conn.InsertAsync(exercise);
    }
    
    public async System.Threading.Tasks.Task<int> UpdateExerciseAsync(TasksManager.Models.Exercise exercise)
    {
        await InitAsync();
        return await conn.UpdateAsync(exercise);
    }
    
    public async System.Threading.Tasks.Task<int> DeleteExerciseAsync(TasksManager.Models.Exercise exercise)
    {
        await InitAsync();
        return await conn.DeleteAsync(exercise);
    }
    
    //new
    public async System.Threading.Tasks.Task<int> DeleteCompletedExercisesAsync()
    {
        await InitAsync();
        return await conn.Table<TasksManager.Models.Exercise>().DeleteAsync(t => t.IsCompleted);
    }
    
    public async System.Threading.Tasks.Task UpdateExpiredStatusesAsync()
    {
        var exercises = await GetExercisesAsync();
        foreach (var ex in exercises.Where(t => !t.IsCompleted))
        {
            ex.UpdateExpiredStatus();
            await UpdateExerciseAsync(ex);
        }
    }

}