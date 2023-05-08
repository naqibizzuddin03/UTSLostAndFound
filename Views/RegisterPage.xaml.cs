using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = new RegisterPageViewModel();
    }

}