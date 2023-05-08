using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class AllProduct : ContentPage
{
    public AllProduct()
    {
        InitializeComponent();
        BindingContext = new AllProductViewModel();
    }
}