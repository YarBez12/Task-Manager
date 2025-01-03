﻿using TasksManager.Views;

namespace TasksManager;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(AddTaskPage), typeof(AddTaskPage));
        Routing.RegisterRoute(nameof(EditTaskPage), typeof(EditTaskPage));
        Routing.RegisterRoute(nameof(AddExercisePage), typeof(AddExercisePage));
        Routing.RegisterRoute(nameof(EditExercisePage), typeof(EditExercisePage));
        Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));

    }
}