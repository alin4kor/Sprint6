using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Threading;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products)); // This is crucial!
            }
        }
        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
        }

        public async void LoadProducts()
        {
            var products = await Task.Run(() => _productService.GetAll());

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Products = new ObservableCollection<Product>(products);
            });
        }
    }
}
