using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views
{
    public partial class AboutUsPage : ContentPage
    {
        public AboutUsPage()
        {
            InitializeComponent();
            BindingContext = new AboutUsViewModel();
        }
    }
}