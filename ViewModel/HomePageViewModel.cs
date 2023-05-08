

using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; private set; }
        public ICommand CategoryTapCommand { get; private set; }

        public ObservableCollection<CategoriesModel> _CategoriesDataList = new ObservableCollection<CategoriesModel>();
        public ObservableCollection<CategoriesModel> CategoriesDataList
        {
            get
            {
                return _CategoriesDataList;
            }
            set
            {
                _CategoriesDataList = value;
                OnPropertyChanged("CategoriesDataList");
            }
        }

        public ObservableCollection<ProductListModel> _LostItemDataList = new ObservableCollection<ProductListModel>();
        public ObservableCollection<ProductListModel> LostItemDataList
        {
            get
            {
                return _LostItemDataList;
            }
            set
            {
                _LostItemDataList = value;
                OnPropertyChanged("LostItemDataList");
            }
        }

        public ObservableCollection<ProductListModel> _FoundItemDataList = new ObservableCollection<ProductListModel>();
        public ObservableCollection<ProductListModel> FoundItemDataList
        {
            get
            {
                return _FoundItemDataList;
            }
            set
            {
                _FoundItemDataList = value;
                OnPropertyChanged("FoundItemDataList");
            }
        }

        public HomePageViewModel()
        {
            PopulateData();
            TapCommand = new Command<ProductListModel>(SelectProduct);
            CategoryTapCommand = new Command<CategoriesModel>(SelectCategory);
        }
        void PopulateData()
        {
            CategoriesDataList.Clear();
            CategoriesDataList.Add(new CategoriesModel() { CategoryID = 1, CategoryName = "Lost", Icon = "\ufb36" });
            CategoriesDataList.Add(new CategoriesModel() { CategoryID = 2, CategoryName = "Found", Icon = "\ufac0" });

            LostItemDataList.Clear();
            LostItemDataList.Add(new ProductListModel() { Name = "Speekah", LastSeen = "Last seen:", Date = "01/03/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            LostItemDataList.Add(new ProductListModel() { Name = "Leather Wristwatch", LastSeen = "Last seen:", Date = "26/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            LostItemDataList.Add(new ProductListModel() { Name = "ASMR device", LastSeen = "Last seen:", Date = "18/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            LostItemDataList.Add(new ProductListModel() { Name = "Overpriced earbuds", LastSeen = "Last seen:", Date = "04/05/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });

        }

        private async void SelectProduct(ProductListModel obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetails());
        }

        private async void SelectCategory(CategoriesModel obj)
        {
            if (obj.CategoryName == "Lost")
            {
                await Application.Current.MainPage.Navigation.PushAsync(new LostProduct());
            }
            else if (obj.CategoryName == "Found")
            {
                await Application.Current.MainPage.Navigation.PushAsync(new FoundProduct());
            }
        }
    }
}
