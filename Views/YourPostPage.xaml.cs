using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YourPostPage : ContentPage
    {
        public YourPostPage()
        {
            InitializeComponent();
            BindingContext = new YourPostViewModel();
        }
    }
}
