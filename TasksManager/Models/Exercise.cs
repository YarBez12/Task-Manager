using SQLite;
namespace TasksManager.Models;

[Table("Exercises")]
public class Exercise
{
    [PrimaryKey, AutoIncrement] 
    public int Id { get; set; }
    public string Essence { get; set; } = string.Empty;

    private DateTime _date;

    public DateTime Date
    {
        get => _date; 
        set => _date = value.Date;
    }
    // [Ignore]
    // public DateTime Date => StartTime.Date;
    public bool IsLast { get; set; } = false;
    public int Priority { get; set; } = 1;
    public TimeSpan Duration { get; set; }
    public bool IsCompleted { get; set; } = false;
    public bool IsExpired { get; set; } = false;
    
    [Indexed]
    public int TaskId { get; set; }
    
    public override string ToString()
    {
        return $"{Essence} (Time: {Date:d}, Duration: {Duration})";
    }
    
    public void UpdateCompletedStatus()
    {
        if (IsCompleted) return;
        var now = DateTime.Now.Date;
        IsExpired = (now > Date);
    }
    
}