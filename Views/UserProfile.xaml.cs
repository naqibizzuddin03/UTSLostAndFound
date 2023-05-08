using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views
{
    public partial class UserProfile : ContentPage
    {
        public UserProfile()
        {
            InitializeComponent();
            BindingContext = new UserProfileViewModel();
        }
    }
}