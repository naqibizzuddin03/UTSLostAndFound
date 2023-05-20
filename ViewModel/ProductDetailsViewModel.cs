using UTSLostAndFound.Model;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        public ICommand TapBackCommand { get; set; }
        public ICommand CopyNumberCommand { get; set; }
        public ContactModel SelectedContact { get; set; }

        public bool IsFooterVisible { get; set; } = true;

        private ProductDetail _productDetail = new ProductDetail();
        public ProductDetail ProductDetail
        {
            get => _productDetail;
            set
            {
                _productDetail = value;
                OnPropertyChanged(nameof(ProductDetail));
            }
        }

        private ContactModel _selectedItem;
        public ContactModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ProductDetailsViewModel(ProductListModel selectedItem)
        {
            PopulateData(selectedItem);
            TapBackCommand = new Command(GoBack);
            CopyNumberCommand = new Command<ContactModel>(CopyNumber);
            SelectedContact = ProductDetail.Contact[0];
        }

        private async void GoBack()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async void CopyNumber(ContactModel contact)
        {
            if (contact != null)
            {
                await Clipboard.SetTextAsync(contact.Number);
                await Application.Current.MainPage.DisplayAlert("Success", "The number has been copied to your clipboard", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No contact selected", "OK");
            }
        }

        private void PopulateData(ProductListModel selectedItem)
        {
            ProductDetail.ContactNow = "Contact Now!";
            ProductDetail.Name = selectedItem.Name;
            ProductDetail.Image = selectedItem.Image;
            ProductDetail.Colors = Color.FromArgb("#33427D");
            ProductDetail.Details = selectedItem.Details;

            List<ContactModel> reviewData = new List<ContactModel>();
            reviewData.Add(new ContactModel { ContactNumber = "Contact Number:", Number = selectedItem.ContactNumber });

            ProductDetail.Contact = reviewData;
        }
    }
}


