using UTSLostAndFound.Views;
using System.Windows.Input;
using UTSLostAndFound.Model;

namespace UTSLostAndFound.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; private set; }
        public ICommand SignOutCommand { get; private set; }

        public string Image { get; set; } = "avatar1";

        private RegisteredAccount _currentUser;
        public RegisteredAccount CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public List<ProfileModel> _MenuItems = new List<ProfileModel>();
        public List<ProfileModel> ProfileModel
        {
            get { return _MenuItems; }
            set { _MenuItems = value; }
        }

        public ProfileViewModel()
        {
            CurrentUser = RegisteredAccount.GetRegisteredAccount("admin"); // Replace "admin" with the currently logged-in student ID
            PopulateData();
            CommandInit();
            SignOutCommand = new Command(SignOut);
        }

        void PopulateData()
        {
            ProfileModel.Clear();
            ProfileModel.Add(new Model.ProfileModel() { Title = "Edit Profile", Body = "\uf3eb", TargetType = typeof(EditProfilePage) });
            ProfileModel.Add(new Model.ProfileModel() { Title = "About Us", Body = "\uf34e", TargetType = typeof(AboutUsPage) });
        }

        private void CommandInit()
        {
            TapCommand = new Command<ProfileModel>(item =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(((Page)Activator.CreateInstance(item.TargetType)));
            });
        }

        private void SignOut()
        {
            // Perform sign-out logic here
            // For example, navigate to the login page
            Application.Current.MainPage = new LoginPage();
        }
    }
}