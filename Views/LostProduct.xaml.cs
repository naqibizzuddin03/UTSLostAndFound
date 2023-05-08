using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class LostProduct : ContentPage
{
    public LostProduct()
    {
        InitializeComponent();
        BindingContext = new LostProductViewModel();
    }
}