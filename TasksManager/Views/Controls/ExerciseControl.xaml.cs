using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManager.Views.Controls;

public partial class ExerciseControl : ContentView
{
    public ExerciseControl()
    {
        InitializeComponent();
        PasteButton.IsVisible = App.Buffer.HasCopy();
    }
}