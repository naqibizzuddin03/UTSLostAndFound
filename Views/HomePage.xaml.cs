using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = new HomePageViewModel();
    }

}