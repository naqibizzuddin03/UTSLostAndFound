using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views
{
    public partial class CreateNewPostPage : ContentPage
    {
        public CreateNewPostPage()
        {
            InitializeComponent();
            BindingContext = new NewPostViewModel();
        }
    }
}
