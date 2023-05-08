using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; private set; }
        public ICommand SignOutCommand { get; private set; }

        public string Name { get; set; } = "Rick Astley";
        public string Email { get; set; } = "1234567890";
        public string ImageUrl { get; set; } = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Avatar.png";

        public List<MenuItems> _MenuItems = new List<MenuItems>();
        public List<MenuItems> MenuItems
        {
            get { return _MenuItems; }
            set { _MenuItems = value; }
        }

        public ProfileViewModel()
        {
            PopulateData();
            CommandInit();
            SignOutCommand = new Command(SignOut);
        }

        void PopulateData()
        {
            MenuItems.Clear();
            MenuItems.Add(new Model.MenuItems() { Title = "Edit Profile", Body = "\uf3eb", TargetType = typeof(EditProfilePage) });
            MenuItems.Add(new Model.MenuItems() { Title = "About Us", Body = "\uf34e", TargetType = typeof(AboutUsPage) });
            MenuItems.Add(new Model.MenuItems() { Title = "Notifications", Body = "\uf09c", TargetType = typeof(Notification) });
        }

        private void CommandInit()
        {
            TapCommand = new Command<MenuItems>(item =>
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