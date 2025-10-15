using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class ProductView : ContentPage
{
    private ProductViewModel pvm;
	public ProductView(ProductViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        pvm = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        pvm.LoadProducts();
    }
}