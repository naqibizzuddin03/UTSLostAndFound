using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            InitializeComponent();
            BindingContext = new EditProfileViewModel();
        }
    }
}
