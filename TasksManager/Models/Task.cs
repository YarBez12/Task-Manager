namespace TasksManager.Models;

public class Task
{
    public int Id { get; internal set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    protected DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime DueDate { get; set; }
    public TaskPriority Priority { get; set; } = TaskPriority.Low;
    public bool IsCompleted { get; set; } = false;
    public bool IsOverdue { get; set; } = false;
    
    public override string ToString()
    {
        return $"{Title} (Priority: {Priority}, Due: {DueDate:MM/dd/yyyy}, Completed: {IsCompleted})";
    }
    
}