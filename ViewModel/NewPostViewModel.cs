using System.ComponentModel;
using System.Windows.Input;
using UTSLostAndFound.Model;
using UTSLostAndFound.Views;

namespace UTSLostAndFound.ViewModel
{
    //Exception handling is implemented in this ViewModel (can refer to line 86)
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
                        Data.Image = base64String;
                        Data.ImageData = bytes;
                        UploadedImage = ImageSource.FromStream(() => new MemoryStream(bytes));
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Handle unauthorized access exception
                Console.WriteLine("Access to media is unauthorized.");
            }
            catch (NotSupportedException)
            {
                // Handle not supported exception
                Console.WriteLine("Picking photos is not supported on this platform.");
            }
            catch (System.Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void Post()
        {
            // Check if any required field is empty
            if (string.IsNullOrEmpty(Data.ProductName) || string.IsNullOrEmpty(Data.Date))
            {
                // Display error message
                Application.Current.MainPage.DisplayAlert("Error", "Thou shall not pass! Please fill all the fields before posting.", "OK");
                return;
            }

            var newProduct = new ProductListModel
            {
                Name = Data.ProductName,
                LastSeen = "Last seen:",
                Date = Data.Date,
                Image = Data.Image,
                ImageData = Data.ImageData,
                Details = Data.Details,
                ContactNumber = Data.ContactNumber
            };

            if (CategoryEntry == "Lost")
            {
                ItemData.LostItemDataList.Add(newProduct);
            }
            else if (CategoryEntry == "Found")
            {
                ItemData.FoundItemDataList.Add(newProduct);
            }

            // Navigate to the homepage within the AppShell
            var appShell = new AppShell();
            var navigation = appShell.CurrentItem.Navigation;
            navigation.PopToRootAsync();
            navigation.PushAsync(new HomePage());

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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
