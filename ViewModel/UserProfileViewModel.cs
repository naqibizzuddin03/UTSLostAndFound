using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class UserProfileViewModel : BaseViewModel
    {
        public ICommand EditProfileCommand { get; private set; }

        public string UserName { get; set; } = "Rick Astley";
        public string StudentID { get; set; } = "1234567890";
        public string Password { get; set; } = "********";

        public UserProfileViewModel()
        {
            CommandInit();
        }

        private void CommandInit()
        {
            EditProfileCommand = new Command(EditProfilePage);
        }

        private void EditProfilePage()
        {
            // Perform edit profile logic here
            // For example, navigate to the edit profile page
            Application.Current.MainPage.Navigation.PushModalAsync(new EditProfilePage());
        }
    }
}