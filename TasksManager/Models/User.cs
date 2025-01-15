namespace TasksManager.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public  string Password { get; set; } = string.Empty;
    public DateTime RegisterDate { get; private set; } = DateTime.Now;
    public List<Task> Tasks { get; set; } = new List<Task>();
    
    public override string ToString()
    {
        return $"{Name} ({Email}, Registered At: {RegisterDate:MM/dd/yyyy})";
    }
    
}