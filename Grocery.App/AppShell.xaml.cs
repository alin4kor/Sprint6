using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Models;
using Grocery.Core.Services;

namespace Grocery.App
{
    public partial class AppShell : Shell
    {
        private bool _isAdmin;
        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                    OnPropertyChanged();
                }
            }
        }
        public AppShell(ViewModels.GlobalViewModel globalViewModel)
        {
            InitializeComponent();
            IsAdmin = globalViewModel.Client.Role == Role.Admin;
            Routing.RegisterRoute(nameof(GroceryListItemsView), typeof(GroceryListItemsView));
            Routing.RegisterRoute(nameof(ProductView), typeof(ProductView));
            Routing.RegisterRoute(nameof(NewProductView), typeof(NewProductView));
            Routing.RegisterRoute(nameof(ChangeColorView), typeof(ChangeColorView));
            Routing.RegisterRoute("Login", typeof(LoginView));
            Routing.RegisterRoute(nameof(BestSellingProductsView), typeof(BestSellingProductsView));
            Routing.RegisterRoute(nameof(BoughtProductsView), typeof(BoughtProductsView));
            Routing.RegisterRoute(nameof(CategoriesView), typeof(CategoriesView));
            Routing.RegisterRoute(nameof(ProductCategoriesView), typeof(ProductCategoriesView));
        }
    }
}
