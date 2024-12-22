

using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksManager.Models;

namespace TasksManager.ViewModels;

public partial class SelectionItemListViewModel<T> : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<SelectionItemViewModel<T>> items;
    
    [ObservableProperty]
    private bool areAllItemsSelected = true;

    public SelectionItemListViewModel()
    {
        Items = new ObservableCollection<SelectionItemViewModel<T>>();
        foreach (var item in (T[])Enum.GetValues(typeof(T)))
        {
            Items.Add(new SelectionItemViewModel<T>(item, UpdateAreAllItemsSelected));
        }
        // foreach (var category in Categories)
        // {
        //     category.PropertyChanged += OnCategoryPropertyChanged;
        // }

        SelectAllItems();
    }

    private void SelectAllItems()
    {
        foreach (var item in Items)
        {
            item.IsSelected = true;
        }
    }
    
    private void DeselectAllItems()
    {
        foreach (var item in Items)
        {
            item.IsSelected = false;
        }
    }

    // [RelayCommand]
    partial void OnAreAllItemsSelectedChanged(bool value)
    {
        if (_suppressItemSelectionChange) { return; }
        if (value)
        {
            SelectAllItems();
        }
        else
        {
            DeselectAllItems();
        }
    }

    // [RelayCommand]
    // private void AreAllCategoriesSelectedChanged()
    // {
    //     
    // }

    public List<T> GetSelectedItems()
    {
        return Items.Where(x => x.IsSelected)
            .Select(x => (T)Enum.Parse(typeof(T), x.Name)).ToList();
    }
    
    private bool _suppressItemSelectionChange = false;
    public void UpdateAreAllItemsSelected()
    {
        _suppressItemSelectionChange = true;
        AreAllItemsSelected = Items.All(c => c.IsSelected);
        _suppressItemSelectionChange = false;
    }
    
    // private void OnCategoryPropertyChanged(object? sender, PropertyChangedEventArgs e)
    // {
    //     if (e.PropertyName == nameof(CategoryViewModel.IsSelected))
    //     {
    //         AreAllCategoriesSelected = Categories.All(c => c.IsSelected);
    //     }
    // }

    // [RelayCommand]
    // private void Cancel()
    // {
    //     
    // }
}