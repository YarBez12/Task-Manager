using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;

namespace TasksManager.Views;

public partial class OverdueSelectionPopup : Popup
{
    public OverdueSelectionPopup()
    {
        InitializeComponent();
        OverduePopupControl.OnPopupResult += OnPopupResult;
        OverduePopupControl.SetTitle("Select Overdue Filter");
    }
    private void OnPopupResult(bool result)
    {
        Close(result);
    }
}