namespace TasksManager.Models;

public class TaskRepository
{
    private static int _nextId = 4;

    private static List<Task> _tasks = new List<Task>
    {
        new Task { Id = 1, Title = "Test Task 1", Description = "This is a test task.", DueDate = DateTime.Now.AddDays(1), Priority = TaskPriority.High },
        new Task { Id = 2, Title = "Test Task 2", Description = "Another test task.", DueDate = DateTime.Now.AddDays(3), Priority = TaskPriority.Medium },
        new Task { Id = 3, Title = "Test Task 3", Description = "Another test task111.", DueDate = DateTime.Now.AddDays(6), Priority = TaskPriority.Medium, IsCompleted = true}
    };

    public static List<Task> GetTasks()
    {
        return _tasks;
    }

    public static Task GetTaskById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public static void AddTask(Task task)
    {
        task.Id = _nextId++;
        _tasks.Add(task);
    }
    
    public static void UpdateTask(Task task)
    {
        var existingTask = GetTaskById(task.Id);
        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.DueDate = task.DueDate;
            existingTask.Priority = task.Priority;
            existingTask.IsCompleted = task.IsCompleted;
        }
    }
    
    public static void DeleteTask(int id)
    {
        var taskToDelete = _tasks.FirstOrDefault(t => t.Id == id);
        if (taskToDelete != null)
        {
            _tasks.Remove(taskToDelete);
        }
    }
}