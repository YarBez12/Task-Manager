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
        try
        {
            InitializeComponent();
            TaskRepository = taskRepository;
            MainPage = new AppShell();
        }
        catch (Exception ex)
        {
            // Логируйте ошибку
            Console.WriteLine($"Initialization error: {ex.Message}");
            MainPage = new ContentPage
            {
                Content = new Label
                {
                    Text = $"Application failed to start: {ex.Message}",
                    TextColor = Colors.Red,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                }
            };
        }
    }
}