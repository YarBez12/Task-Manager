using Microsoft.Extensions.Logging;
using TasksManager.Models;
using TasksManager.Services;
using TasksManager.ViewModels;
using TasksManager.Views;
using CommunityToolkit.Maui;
using Plugin.LocalNotification;

namespace TasksManager;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            // .UseLocalNotification()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        // builder.UseMauiApp<App>().UseMauiCommunityToolkit();
        string dbTaskPath = Path.Combine(FileSystem.AppDataDirectory, "TasksManager.db3");
        // builder.Services.AddSingleton(new TaskRepository(dbPath));
        builder.Services.AddSingleton<TaskRepository>(s => ActivatorUtilities.CreateInstance<TaskRepository>(s,dbTaskPath));
        string dbExercisePath = Path.Combine(FileSystem.AppDataDirectory, "ExerciseManager.db3");
        builder.Services.AddSingleton<ExerciseRepository>(s => ActivatorUtilities.CreateInstance<ExerciseRepository>(s,dbExercisePath));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}