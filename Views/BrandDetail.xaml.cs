using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class BrandDetail : ContentPage
{
    public BrandDetail()
    {
        InitializeComponent();
        BindingContext = new BrandDetailViewModel();
    }
}