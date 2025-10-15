using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.Input;


namespace Grocery.App.ViewModels
{
    public partial class NewProductViewModel : BaseViewModel
    {
        private readonly IProductService _productService;

        [ObservableProperty]
        private string name = "";

        [ObservableProperty]
        private int stock = 0;

        [ObservableProperty]
        private DateTime shelfLife = DateTime.Now;

        [ObservableProperty]
        private Decimal price = 0.0m;

        [ObservableProperty]
        private string addMessage;

        public NewProductViewModel(IProductService productService)
        {
            _productService = productService;
        }

        [RelayCommand]
        private void AddProduct()
        {
            Product product = new(0, Name, Stock, DateOnly.FromDateTime(ShelfLife), Price);
            try
            {
                product = _productService.Add(product);
                AddMessage = "Product created!";
                Name = "";
                Price = 0.0m;
                ShelfLife = DateTime.Now;
                Stock = 0;
            }
            catch (Exception e)
            {
                AddMessage = "error: " + e.Message;
            }
        }
    }
}
