namespace TasksManager.Models;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    private string PasswordHash { get; set; } = string.Empty;
    public DateTime RegisterDate { get; private set; } = DateTime.Now;
    public List<Task> Tasks { get; set; } = new List<Task>();
    
    private string HashPassword(string password)
    {
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public override string ToString()
    {
        return $"{Name} ({Email}, Registered At: {RegisterDate:MM/dd/yyyy})";
    }
    
}