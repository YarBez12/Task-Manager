using TasksManager.Models;
using TasksManager.Views;

namespace TasksManager;

public partial class App : Application
{
    public static TaskRepository TaskRepository { get; private set; }
    // public App() : this(Path.Combine(FileSystem.AppDataDirectory, "TasksManager.db")) { }

    public App(TaskRepository taskRepository)
    {
        // InitializeComponent();
        // TaskRepository = new TaskRepository(dbPath);
        // MainPage = new AppShell();
        InitializeComponent();
        TaskRepository = taskRepository;
        MainPage = new AppShell();
    }
}