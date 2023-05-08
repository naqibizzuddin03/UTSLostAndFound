using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views
{
    public partial class Notification : ContentPage
    {
        public Notification()
        {
            InitializeComponent();
            BindingContext = new NotificationViewModel();
        }
    }
}