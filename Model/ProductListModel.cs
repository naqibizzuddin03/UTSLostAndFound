using System.ComponentModel;

namespace UTSLostAndFound.Model
{
    public class ProductListModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _lastSeen;
        public string LastSeen
        {
            get => _lastSeen;
            set
            {
                if (_lastSeen != value)
                {
                    _lastSeen = value;
                    OnPropertyChanged(nameof(LastSeen));
                }
            }
        }

        private string _date;
        public string Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        private string _details;
        public string Details
        {
            get => _details;
            set
            {
                if (_details != value)
                {
                    _details = value;
                    OnPropertyChanged(nameof(Details));
                }
            }
        }

        private string _contactNumber;
        public string ContactNumber
        {
            get => _contactNumber;
            set
            {
                if (_contactNumber != value)
                {
                    _contactNumber = value;
                    OnPropertyChanged(nameof(ContactNumber));
                }
            }
        }

        private string _image;
        public string Image
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(nameof(Image));
                    OnPropertyChanged(nameof(ImageSource));
                }
            }
        }

        private byte[] _imageData;
        public byte[] ImageData
        {
            get => _imageData;
            set
            {
                if (_imageData != value)
                {
                    _imageData = value;
                    OnPropertyChanged(nameof(ImageData));
                    OnPropertyChanged(nameof(ImageSource));
                }
            }
        }

        public ImageSource ImageSource
        {
            get
            {
                if (!string.IsNullOrEmpty(Image))
                {
                    // Return ImageSource from string path if available
                    return ImageSource.FromFile(Image);
                }
                else if (ImageData != null && ImageData.Length > 0)
                {
                    // Return ImageSource from byte array if available
                    return ImageSource.FromStream(() => new MemoryStream(ImageData));
                }
                else
                {
                    // Return a default image source if no image data is available
                    return ImageSource.FromFile("placeholder_image.png");
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}