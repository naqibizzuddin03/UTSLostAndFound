using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class BrandDetailViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; private set; }
        public ICommand TapCommandMenu { get; private set; }

        public ObservableCollection<TabPageModel> _TabPageList = new ObservableCollection<TabPageModel>();
        public ObservableCollection<TabPageModel> TabPageList
        {
            get
            {
                return _TabPageList;
            }
            set
            {
                _TabPageList = value;
                OnPropertyChanged("TabPageList");
            }
        }

        public ObservableCollection<ProductListModel> _AllProductDataList = new ObservableCollection<ProductListModel>();
        public ObservableCollection<ProductListModel> AllProductDataList
        {
            get
            {
                return _AllProductDataList;
            }
            set
            {
                _AllProductDataList = value;
                OnPropertyChanged("AllProductDataList");
            }
        }
        public BrandDetailViewModel()
        {
            PopulateData();
            TapCommand = new Command<ProductListModel>(SelectProduct);
            TapCommandMenu = new Command<TabPageModel>(SelectMenu);
        }
        private async void SelectProduct(ProductListModel obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetails());
        }

        private void SelectMenu(TabPageModel obj)
        {
            foreach (var item in TabPageList)
            {
                if (item.Id == obj.Id)
                {
                    item.IsSelected = true;
                }
                else
                {
                    item.IsSelected = false;
                }
            }

        }
        void PopulateData()
        {
            AllProductDataList.Clear();
            AllProductDataList.Clear();
            AllProductDataList.Add(new ProductListModel() { Name = "Speekah", LastSeen = "Last seen:", Date = "01/03/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Leather Wristwatch", LastSeen = "Last seen:", Date = "26/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "ASMR device", LastSeen = "Last seen:", Date = "18/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Overpriced earbuds", LastSeen = "Last seen:", Date = "04/05/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
        }
    }
}
