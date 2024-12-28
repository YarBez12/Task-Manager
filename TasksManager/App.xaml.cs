using TasksManager.Models;
using TasksManager.Views;
using TasksManager.Services;

namespace TasksManager;

public partial class App : Application
{
    public static TaskRepository TaskRepository { get; private set; }
    public static ExerciseRepository ExerciseRepository { get; private set; }
    // private Timer _notificationTimer;
    // public App() : this(Path.Combine(FileSystem.AppDataDirectory, "TasksManager.db")) { }

    public App(TaskRepository taskRepository, ExerciseRepository exerciseRepository)
    {
        // InitializeComponent();
        // TaskRepository = new TaskRepository(dbPath);
        // MainPage = new AppShell();
        InitializeComponent();
        TaskRepository = taskRepository;
        ExerciseRepository = exerciseRepository;
        MainPage = new AppShell();
        // _notificationTimer = new Timer(async _ =>
        // {
        //     var notificationService = new TaskNotificationService();
        //     await notificationService.CheckAndNotifyAsync();
        // }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
    }
    
    // protected override void OnSleep()
    // {
    //     _notificationTimer?.Dispose();
    // }

    // protected override void OnResume()
    // {
    //     _notificationTimer = new Timer(async _ =>
    //     {
    //         var notificationService = new TaskNotificationService();
    //         await notificationService.CheckAndNotifyAsync();
    //     }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
    // }
}