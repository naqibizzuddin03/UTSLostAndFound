using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class ProductDetails : ContentPage
{
    ProductDetailsViewModel viewModel;
    public ProductDetails()
    {
        InitializeComponent();
        BindingContext = viewModel = new ProductDetailsViewModel();
    }

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
        viewModel.ChageFooterVisibility(e.ScrollY);
    }
}