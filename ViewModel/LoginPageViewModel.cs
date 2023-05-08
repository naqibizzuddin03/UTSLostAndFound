

using UTSLostAndFound.Views;
using System.Windows.Input;

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
            // Add your login logic here
            // Example: Validate the student ID and password
            if (StudentId == "admin" && Password == "admin")
            {
                // Successful login
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                // Invalid login credentials, show an error message
                Application.Current.MainPage.DisplayAlert("Error", "Invalid student ID or password.", "OK");
            }
        }


        private void Register()
        {
            // Add your registration logic here
            Application.Current.MainPage = new RegisterPage();
        }
    }
}

