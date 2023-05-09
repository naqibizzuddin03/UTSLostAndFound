using System.ComponentModel;
using System.Windows.Input;
using UTSLostAndFound.Model;
using UTSLostAndFound.Views;

namespace UTSLostAndFound.ViewModel
{
    public class NewPostViewModel : BaseViewModel
    {
        private string _categoryEntry;
        public string CategoryEntry
        {
            get => _categoryEntry;
            set
            {
                if (_categoryEntry != value)
                {
                    _categoryEntry = value;
                    OnPropertyChanged(nameof(CategoryEntry));
                }
            }
        }

        private Data _data;
        public Data Data
        {
            get => _data;
            set
            {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }

        private ImageSource _uploadedImage;
        public ImageSource UploadedImage
        {
            get => _uploadedImage;
            set
            {
                if (_uploadedImage != value)
                {
                    _uploadedImage = value;
                    OnPropertyChanged(nameof(UploadedImage));
                }
            }
        }

        public ICommand PostCommand { get; set; }
        public ICommand UploadImageCommand { get; set; }

        public NewPostViewModel()
        {
            Data = new Data();
            PostCommand = new Command(Post);
            UploadImageCommand = new Command(async () => await UploadImage());
        }

        private async Task UploadImage()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pick a photo"
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await stream.CopyToAsync(ms);
                        var bytes = ms.ToArray();
                        var base64String = System.Convert.ToBase64String(bytes);
                        Data.ImageUrl = base64String;
                        UploadedImage = ImageSource.FromStream(() => new MemoryStream(bytes));
                    }
                }
            }
            catch (System.Exception ex)
            {
                // Handle exception
            }
        }

        private void Post()
        {
            var newProduct = new ProductListModel
            {
                Name = Data.ProductName,
                LastSeen = Data.LastSeen + ":",
                Date = Data.Date.ToString(),
                ImageUrl = Data.ImageUrl
            };

            // Add the new product to the AllProductDataList in YourPostViewModel
            YourPostViewModel vm = new YourPostViewModel();
            vm.AllProductDataList.Add(newProduct);

            AppShell appShell = new AppShell();
            Application.Current.MainPage = new HomePage();
            Application.Current.MainPage = appShell;
        }
    }

    public class Data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged(nameof(ProductName));
                }
            }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                if (_imageUrl != value)
                {
                    _imageUrl = value;
                    OnPropertyChanged(nameof(ImageUrl));
                }
            }
        }

        private Nullable<DateTime> _date;
        public Nullable<DateTime> Date
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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}