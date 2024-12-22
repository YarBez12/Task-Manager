using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;

namespace TasksManager.Views.Controls;

public partial class SelectionPopupControl : ContentView
{
    public event Action<bool> OnPopupResult;
    public void SetTitle(string title)
    {
        titleLabel.Text = title;
    }
    public SelectionPopupControl()
    {
        InitializeComponent();
        
    }
    private void OnCloseCommand(object sender, EventArgs e)
    {
        OnPopupResult?.Invoke(false);
    }
    
    private void OnSaveCommand(object sender, EventArgs e)
    {
        OnPopupResult?.Invoke(true);
    }
}