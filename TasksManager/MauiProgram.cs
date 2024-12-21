using Microsoft.Extensions.Logging;
using TasksManager.Models;
using TasksManager.Services;
using TasksManager.ViewModels;
using TasksManager.Views;

namespace TasksManager;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TasksManager.db3");
        // builder.Services.AddSingleton(new TaskRepository(dbPath));
        builder.Services.AddSingleton<TaskRepository>(s => ActivatorUtilities.CreateInstance<TaskRepository>(s,dbPath));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}