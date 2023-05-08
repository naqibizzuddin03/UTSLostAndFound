using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class NotificationViewModel : BaseViewModel
    {
        private bool _isNotificationEnabled;
        public bool IsNotificationEnabled
        {
            get { return _isNotificationEnabled; }
            set
            {
                if (_isNotificationEnabled != value)
                {
                    _isNotificationEnabled = value;
                    OnPropertyChanged(nameof(IsNotificationEnabled));
                }
            }
        }

        public ICommand ToggleNotificationCommand { get; private set; }

        public NotificationViewModel()
        {
            ToggleNotificationCommand = new Command(ToggleNotification);
        }

        private void ToggleNotification()
        {
            IsNotificationEnabled = !IsNotificationEnabled;
            // Implement logic for enabling/disabling notifications here
        }
    }
}