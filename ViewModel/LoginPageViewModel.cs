using UTSLostAndFound.Views;
using System.Windows.Input;
using UTSLostAndFound.Model;

namespace UTSLostAndFound.ViewModel
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string _studentId;
        private string _password;

        public string StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                OnPropertyChanged("StudentId");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(Register);
        }

        private void Login()
        {
            RegisteredAccount account = RegisteredAccount.GetRegisteredAccount(StudentId);

            if (account != null && account.Password == Password)
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Invalid student ID or password.", "OK");
            }
        }

        private void Register()
        {
            Application.Current.MainPage = new RegisterPage();
        }
    }
}
