using SQLite;
// using ThreadingTask = System.Threading.Tasks.Task;
// using ThreadingTask = System.Threading.Tasks.Task;


namespace TasksManager.Models;
public class TaskRepository
{
    string _dbPath;
    private SQLiteAsyncConnection conn;
    // private readonly SQLiteAsyncConnection _database;
    // private static int _nextId = 4;

    // private static List<Task> _tasks = new List<Task>
    // {
    //     new Task { Id = 1, Title = "Test Task 1", Description = "This is a test task.", DueDate = DateTime.Now.AddDays(1), Priority = TaskPriority.High },
    //     new Task { Id = 2, Title = "Test Task 2", Description = "Another test task.", DueDate = DateTime.Now.AddDays(3), Priority = TaskPriority.Medium },
    //     new Task { Id = 3, Title = "Test Task 3", Description = "Another test task111.", DueDate = DateTime.Now.AddDays(6), Priority = TaskPriority.Medium, IsCompleted = true}
    // };

    public TaskRepository(string dbPath)
    {
        _dbPath = dbPath;
        // if (_database != null)
        //     return;
        // _database = new SQLiteAsyncConnection(dbPath);
        // _database.CreateTableAsync<TasksManager.Models.Task>().Wait();
    }

    private async System.Threading.Tasks.Task InitAsync()
    {
        if (conn != null)
            return;
        conn = new SQLiteAsyncConnection(_dbPath);
        // await conn.ExecuteAsync("DROP TABLE IF EXISTS Tasks");
        await conn.CreateTableAsync<TasksManager.Models.Task>();
    }

    // public static List<Task> GetTasks()
    // {
    //     return _tasks;
    // }
    //
    // public static Task GetTaskById(int id)
    // {
    //     return _tasks.FirstOrDefault(t => t.Id == id);
    // }
    //
    // public static void AddTask(Task task)
    // {
    //     task.Id = _nextId++;
    //     _tasks.Add(task);
    // }
    //
    // public static void UpdateTask(Task task)
    // {
    //     var existingTask = GetTaskById(task.Id);
    //     if (existingTask != null)
    //     {
    //         existingTask.Title = task.Title;
    //         existingTask.Description = task.Description;
    //         existingTask.DueDate = task.DueDate;
    //         existingTask.Priority = task.Priority;
    //         existingTask.IsCompleted = task.IsCompleted;
    //     }
    // }
    //
    // public static void DeleteTask(int id)
    // {
    //     var taskToDelete = _tasks.FirstOrDefault(t => t.Id == id);
    //     if (taskToDelete != null)
    //     {
    //         _tasks.Remove(taskToDelete);
    //     }
    // }
    
    public async System.Threading.Tasks.Task<List<TasksManager.Models.Task>> GetTasksAsync()
    {
        await InitAsync();
        var r = await conn.Table<TasksManager.Models.Task>().ToListAsync();
        return await conn.Table<TasksManager.Models.Task>().ToListAsync();
    }

    public async System.Threading.Tasks.Task<TasksManager.Models.Task> GetTaskByIdAsync(int id)
    {
        await InitAsync();
        return await conn.Table<TasksManager.Models.Task>().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async System.Threading.Tasks.Task<int> AddTaskAsync(TasksManager.Models.Task task)
    {
        await InitAsync();
        var result = await conn.InsertAsync(task);
        return result;
    }
    
    public async System.Threading.Tasks.Task<int> UpdateTaskAsync(TasksManager.Models.Task task)
    {
        await InitAsync();
        return await conn.UpdateAsync(task);
    }
    
    public async System.Threading.Tasks.Task<int> DeleteTaskAsync(TasksManager.Models.Task task)
    {
        await InitAsync();
        return await conn.DeleteAsync(task);
    }
    
    //new
    public async System.Threading.Tasks.Task<int> DeleteCompletedTasksAsync()
    {
        await InitAsync();
        return await conn.Table<TasksManager.Models.Task>().DeleteAsync(t => t.IsCompleted);
    }
}