
using UTSLostAndFound.Views;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class RegisterPageViewModel : BaseViewModel
    {
        public ICommand RegisterCommand { get; private set; }

        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(OnRegister);
        }

        private void OnRegister()
        {
            // Perform registration logic here

            // Navigate back to the login page
            Application.Current.MainPage = new LoginPage();
        }
    }
}
