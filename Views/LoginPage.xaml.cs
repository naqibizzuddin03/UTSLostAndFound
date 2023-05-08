using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginPageViewModel();
    }
}


