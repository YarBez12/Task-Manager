// using System.Collections.ObjectModel;
// using System.ComponentModel;
// using CommunityToolkit.Mvvm.ComponentModel;
// using CommunityToolkit.Mvvm.Input;
// using TasksManager.Models;
//
// namespace TasksManager.ViewModels;
//
// public partial class CategoryListViewModel : ObservableObject
// {
//     [ObservableProperty]
//     private ObservableCollection<CategoryViewModel> items;
//     
//     [ObservableProperty]
//     private bool areAllSelected = true;
//
//     public CategoryListViewModel()
//     {
//         Items = new ObservableCollection<CategoryViewModel>();
//         foreach (TaskCategory category in (TaskCategory[])Enum.GetValues(typeof(TaskCategory)))
//         {
//             Items.Add(new CategoryViewModel(category, UpdateAreAllCategoriesSelected));
//         }
//         // foreach (var category in Categories)
//         // {
//         //     category.PropertyChanged += OnCategoryPropertyChanged;
//         // }
//
//         SelectAllCategories();
//     }
//
//     private void SelectAllCategories()
//     {
//         foreach (var category in Items)
//         {
//             category.IsSelected = true;
//         }
//     }
//     
//     private void DeselectAllCategories()
//     {
//         foreach (var category in Items)
//         {
//             category.IsSelected = false;
//         }
//     }
//
//     // [RelayCommand]
//     partial void OnAreAllSelectedChanged(bool value)
//     {
//         if (_suppressCategorySelectionChange) { return; }
//         if (value)
//         {
//             SelectAllCategories();
//         }
//         else
//         {
//             DeselectAllCategories();
//         }
//     }
//
//     // [RelayCommand]
//     // private void AreAllCategoriesSelectedChanged()
//     // {
//     //     
//     // }
//
//     public List<TaskCategory> GetSelectedCategories()
//     {
//         return Items.Where(x => x.IsSelected)
//             .Select(x => (TaskCategory)Enum.Parse(typeof(TaskCategory), x.Name)).ToList();
//     }
//     
//     private bool _suppressCategorySelectionChange = false;
//     public void UpdateAreAllCategoriesSelected()
//     {
//         _suppressCategorySelectionChange = true;
//         AreAllSelected = Items.All(c => c.IsSelected);
//         _suppressCategorySelectionChange = false;
//     }
//     
//     // private void OnCategoryPropertyChanged(object? sender, PropertyChangedEventArgs e)
//     // {
//     //     if (e.PropertyName == nameof(CategoryViewModel.IsSelected))
//     //     {
//     //         AreAllCategoriesSelected = Categories.All(c => c.IsSelected);
//     //     }
//     // }
//
//     // [RelayCommand]
//     // private void Cancel()
//     // {
//     //     
//     // }
// }