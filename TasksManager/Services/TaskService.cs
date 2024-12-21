using TasksManager.Models;
using Task = TasksManager.Models.Task;
namespace TasksManager.Services;

public class TaskService
{
    public List<Task> GetTasks()
    {
        return TaskRepository.GetTasks();
    }

    public Task GetTaskById(int id)
    {
        return TaskRepository.GetTaskById(id);
    }
    
    public void AddTask(Task task)
    {
        TaskRepository.AddTask(task);
    }

    public void UpdateTask(Task task)
    {
        TaskRepository.UpdateTask(task);
    }

    public void DeleteTask(Task task)
    {
        var tasks = TaskRepository.GetTasks();
        tasks.Remove(task);
    }
    public void DeleteTask(int id)
    {
        TaskRepository.DeleteTask(id);
    }
}