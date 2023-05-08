using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class FoundProduct : ContentPage
{
    public FoundProduct()
    {
        InitializeComponent();
        BindingContext = new FoundProductViewModel();
    }
}