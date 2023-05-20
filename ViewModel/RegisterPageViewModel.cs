using UTSLostAndFound.Views;
using System.Windows.Input;
using UTSLostAndFound.Model;

namespace UTSLostAndFound.ViewModel
{
    public class RegisterPageViewModel : BaseViewModel
    {
        public string StudentId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand RegisterCommand { get; private set; }

        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(OnRegister);
        }

        private void OnRegister()
        {
            // Perform registration logic here

            // Create a new registered account
            RegisteredAccount newAccount = new RegisteredAccount
            {
                StudentId = StudentId,
                Username = Username,
                Password = Password
            };

            // Store the new account in the RegisteredAccount model
            RegisteredAccount.AddRegisteredAccount(newAccount);

            // Navigate back to the login page
            Application.Current.MainPage = new LoginPage();
        }
    }
}
