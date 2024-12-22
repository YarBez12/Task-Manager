using SQLite;

namespace TasksManager.Models;

[Table("Tasks")]
public class Task
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    protected DateTime StartDate { get; set; } = DateTime.Now;
    // public DateTime DueDate { get; set; }
    private DateTime _dueDate;
    public DateTime DueDate
    {
        get => _dueDate; 
        set => _dueDate = value.Date.AddDays(1).AddSeconds(-1);
    }
    public TaskPriority Priority { get; set; } = TaskPriority.Low;
    public TaskCategory Category { get; set; } = TaskCategory.Other; // Новое поле
    public bool IsCompleted { get; set; } = false;
    public TaskOverdueStatus OverdueStatus { get; set; } = TaskOverdueStatus.Upcoming;
    
    public override string ToString()
    {
        return $"{Title} (Priority: {Priority}, Due: {DueDate:MM/dd/yyyy}, Completed: {IsCompleted})";
    }

    public void UpdateOverdueStatus()
    {
        if (IsCompleted) return;
        // var daysOverdue = (DateTime.Now.Date - DueDate.Date).Days;
        // OverdueStatus = daysOverdue switch
        // {
        //     < 0 => TaskOverdueStatus.NotOverdue,
        //     0 => TaskOverdueStatus.OverdueToday,
        //     <=7 => TaskOverdueStatus.OverdueByDays,
        //     _ => TaskOverdueStatus.OverdueCritical
        // };
        var now = DateTime.Now;
        if (now < DueDate)
        {
            OverdueStatus = TaskOverdueStatus.Upcoming;
        }
        else if (now.Date.AddDays(-1) == DueDate.Date)
        {
            OverdueStatus = TaskOverdueStatus.Today;
        }
        else if (now.Date <= DueDate.Date.AddDays(7))
        {
            OverdueStatus = TaskOverdueStatus.Recent;
        }
        else
        {
            OverdueStatus = TaskOverdueStatus.Critical;
        }
    }
    
}