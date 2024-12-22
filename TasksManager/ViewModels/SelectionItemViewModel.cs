using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;

namespace TasksManager.ViewModels;

public partial class SelectionItemViewModel<T> : ObservableObject
{
    private readonly Action? _updateAllItemsAction;
    public string Name { get; }

    [ObservableProperty] 
    public bool isSelected;

    public SelectionItemViewModel(T item, Action? updateAllItemsAction = null)
    {
        Name = item.ToString();
        IsSelected = true;
        _updateAllItemsAction = updateAllItemsAction;
    }
    
    partial void OnIsSelectedChanged(bool value)
    {
        if (_updateAllItemsAction != null)
        {
            _updateAllItemsAction();
        }
    }
}