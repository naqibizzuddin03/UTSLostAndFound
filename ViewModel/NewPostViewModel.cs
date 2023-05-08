using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UTSLostAndFound.Views;

namespace UTSLostAndFound.ViewModel
{
    public class NewPostViewModel : INotifyPropertyChanged
    {
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    // Call a method or update properties based on the selected category
                    HandleCategorySelection();
                    OnPropertyChanged();
                }
            }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private ImageSource _uploadedImage;
        public ImageSource UploadedImage
        {
            get { return _uploadedImage; }
            set { SetProperty(ref _uploadedImage, value); }
        }

        public ICommand UploadImageCommand { get; private set; }
        public ICommand PostCommand { get; private set; }

        public NewPostViewModel()
        {
            UploadImageCommand = new Command(UploadImage);
            PostCommand = new Command(Post);
        }

        private void UploadImage()
        {
            // Implement the logic to upload the image and set the UploadedImage property
        }

        private void Post()
        {
            // Implement the logic to create and save the new post using the provided data
            // For example, you can add the new post to a collection that is displayed in the ExplorePage and YourPostPage
            Application.Current.MainPage = new PostPage();
            Application.Current.MainPage = new AppShell();
        }

        private void HandleCategorySelection()
        {
            // Implement logic based on the selected category
            if (Category == "Lost")
            {
                // Additional logic for "Lost" category
            }
            else if (Category == "Found")
            {
                // Additional logic for "Found" category
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
