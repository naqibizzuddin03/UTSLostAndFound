using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNewPostPage : ContentPage
    {
        public CreateNewPostPage()
        {
            InitializeComponent();
            BindingContext = new NewPostViewModel();
        }
    }
}

