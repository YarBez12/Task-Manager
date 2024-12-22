using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using TasksManager.ViewModels;

namespace TasksManager.Views;

public partial class CategorySelectionPopup : Popup
{
    public CategorySelectionPopup()
    {
        InitializeComponent();
        CategoryPopupControl.OnPopupResult += OnPopupResult;
        CategoryPopupControl.SetTitle("Select Category");
    }
    private void OnPopupResult(bool result)
    {
        Close(result);
    }

    // private void OnCloseCommand(object sender, EventArgs e)
    // {
    //     Close(false);
    // }
    //
    // private void OnSaveCommand(object sender, EventArgs e)
    // {
    //     Close(true);
    // }
}