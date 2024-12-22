
namespace TasksManager.Services;

public class TaskService
{
    public async System.Threading.Tasks.Task<List<TasksManager.Models.Task>> GetTasksAsync()
    {
        return await App.TaskRepository.GetTasksAsync();
    }

    public async System.Threading.Tasks.Task<TasksManager.Models.Task> GetTaskByIdAsync(int id)
    {
        return await App.TaskRepository.GetTaskByIdAsync(id);
    }
    
    public async System.Threading.Tasks.Task<int> AddTaskAsync(TasksManager.Models.Task task)
    {
        return await App.TaskRepository.AddTaskAsync(task);
    }

    public async System.Threading.Tasks.Task<int> UpdateTaskAsync(TasksManager.Models.Task task)
    {
        return await App.TaskRepository.UpdateTaskAsync(task);
    }

    public async System.Threading.Tasks.Task<int> DeleteTaskAsync(TasksManager.Models.Task task)
    {
        return await App.TaskRepository.DeleteTaskAsync(task);
    }
    public async System.Threading.Tasks.Task<int> DeleteTaskAsync(int id)
    {
        var task = await App.TaskRepository.GetTaskByIdAsync(id);
        if (task != null)
        {
            return await App.TaskRepository.DeleteTaskAsync(task);
        }

        return -1;
    }
    
    //new
    public async System.Threading.Tasks.Task<int> DeleteCompletedTasksAsync()
    {
        return await App.TaskRepository.DeleteCompletedTasksAsync();
    }
    
    public async System.Threading.Tasks.Task UpdateOverdueStatusesAsync()
    {
        await App.TaskRepository.UpdateOverdueStatusesAsync();
    }

}