

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
        public ICommand IconTapCommand { get; private set; }

        private string _searchText;
        public ObservableCollection<ProductListModel> _OriginalLostItemDataList = new ObservableCollection<ProductListModel>();
        public ObservableCollection<ProductListModel> _OriginalFoundItemDataList = new ObservableCollection<ProductListModel>();
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
                SearchLostAndFoundItems(_searchText);
            }
        }

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
            IconTapCommand = new Command(GoToCreateNewPostPage);
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

            FoundItemDataList.Clear();
            FoundItemDataList.Add(new ProductListModel() { Name = "Speekah", LastSeen = "Last seen:", Date = "01/03/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            FoundItemDataList.Add(new ProductListModel() { Name = "Leather Wristwatch", LastSeen = "Last seen:", Date = "26/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            FoundItemDataList.Add(new ProductListModel() { Name = "ASMR device", LastSeen = "Last seen:", Date = "18/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            FoundItemDataList.Add(new ProductListModel() { Name = "Overpriced earbuds", LastSeen = "Last seen:", Date = "04/05/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });

            // Clone the original lists
            _OriginalLostItemDataList = new ObservableCollection<ProductListModel>(LostItemDataList);
            _OriginalFoundItemDataList = new ObservableCollection<ProductListModel>(FoundItemDataList);
        }

        private async void SelectProduct(ProductListModel obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetails());
        }

        private void SearchLostAndFoundItems(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var lostItems = _OriginalLostItemDataList.Where(item => item.Name.ToLower().Contains(searchText.ToLower()));
                var foundItems = _OriginalFoundItemDataList.Where(item => item.Name.ToLower().Contains(searchText.ToLower()));

                LostItemDataList = new ObservableCollection<ProductListModel>(lostItems);
                FoundItemDataList = new ObservableCollection<ProductListModel>(foundItems);
            }
            else
            {
                // If search text is empty or null, show all items.
                LostItemDataList = new ObservableCollection<ProductListModel>(_OriginalLostItemDataList);
                FoundItemDataList = new ObservableCollection<ProductListModel>(_OriginalFoundItemDataList);
            }
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

        private async void GoToCreateNewPostPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateNewPostPage());
        }
    }
}
