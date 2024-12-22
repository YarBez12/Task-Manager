using SQLite;

namespace TasksManager.Models;

[Table("Tasks")]
public class Task
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    protected DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime DueDate { get; set; }
    public TaskPriority Priority { get; set; } = TaskPriority.Low;
    public TaskCategory Category { get; set; } = TaskCategory.Other; // Новое поле
    public bool IsCompleted { get; set; } = false;
    public TaskOverdueStatus IsOverdue { get; set; } = TaskOverdueStatus.NotOverdue;
    
    public override string ToString()
    {
        return $"{Title} (Priority: {Priority}, Due: {DueDate:MM/dd/yyyy}, Completed: {IsCompleted})";
    }
    
}