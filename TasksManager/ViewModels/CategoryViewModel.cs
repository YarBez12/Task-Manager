// using CommunityToolkit.Mvvm.ComponentModel;
// using CommunityToolkit.Mvvm.Input;
// using TasksManager.Models;
//
// namespace TasksManager.ViewModels;
//
// public partial class CategoryViewModel : ObservableObject
// {
//     private readonly Action? _updateAllCategoriesAction;
//     public string Name { get; }
//
//     [ObservableProperty] 
//     public bool isSelected;
//
//     public CategoryViewModel(TaskCategory category, Action? updateAllCategoriesAction = null)
//     {
//         Name = category.ToString();
//         IsSelected = true;
//         _updateAllCategoriesAction = updateAllCategoriesAction;
//     }
//     
//     partial void OnIsSelectedChanged(bool value)
//     {
//         if (_updateAllCategoriesAction != null)
//         {
//             _updateAllCategoriesAction();
//         }
//     }
// }