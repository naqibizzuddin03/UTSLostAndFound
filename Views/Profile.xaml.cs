using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views
{
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
        }

        private async void OnSignOutClicked(object sender, EventArgs e)
        {
            // Navigate back to the login page
            await Navigation.PopToRootAsync();
        }
    }
}