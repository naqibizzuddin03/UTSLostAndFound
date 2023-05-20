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
        private ObservableCollection<ProductListModel> _OriginalLostItemDataList;
        private ObservableCollection<ProductListModel> _OriginalFoundItemDataList;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                SearchLostAndFoundItems(_searchText);
            }
        }

        public ObservableCollection<CategoriesModel> CategoriesDataList { get; } = new ObservableCollection<CategoriesModel>()
        {
            new CategoriesModel() { CategoryID = 1, CategoryName = "Lost", Icon = "\ufb36" },
            new CategoriesModel() { CategoryID = 2, CategoryName = "Found", Icon = "\ufac0" }
        };

        public ObservableCollection<ProductListModel> LostItemDataList
        {
            get => ItemData.LostItemDataList;
        }

        public ObservableCollection<ProductListModel> FoundItemDataList
        {
            get => ItemData.FoundItemDataList;
        }

        public HomePageViewModel()
        {
            PopulateData();
            TapCommand = new Command<ProductListModel>(async (selectedItem) =>
            {
                await Shell.Current.Navigation.PushModalAsync(new ProductDetails(selectedItem));
            });
            CategoryTapCommand = new Command<CategoriesModel>(SelectCategory);
            IconTapCommand = new Command(GoToCreateNewPostPage);
        }

        void PopulateData()
        {
            // Clone the original lists
            _OriginalLostItemDataList = new ObservableCollection<ProductListModel>(LostItemDataList);
            _OriginalFoundItemDataList = new ObservableCollection<ProductListModel>(FoundItemDataList);
        }

        private async void SelectCategory(CategoriesModel obj)
        {
            if (obj.CategoryName == "Lost")
            {
                await Shell.Current.Navigation.PushAsync(new LostProduct());
            }
            else if (obj.CategoryName == "Found")
            {
                await Shell.Current.Navigation.PushAsync(new FoundProduct());
            }
        }

        private async void GoToCreateNewPostPage()
        {
            await Shell.Current.Navigation.PushAsync(new CreateNewPostPage());
        }

        private void SearchLostAndFoundItems(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var lostItems = _OriginalLostItemDataList.Where(item => item.Name.ToLower().Contains(searchText.ToLower()));
                var foundItems = _OriginalFoundItemDataList.Where(item => item.Name.ToLower().Contains(searchText.ToLower()));

                LostItemDataList.Clear();
                foreach (var item in lostItems)
                {
                    LostItemDataList.Add(item);
                }

                FoundItemDataList.Clear();
                foreach (var item in foundItems)
                {
                    FoundItemDataList.Add(item);
                }
            }
            else
            {
                // If search text is empty or null, show all items.
                LostItemDataList.Clear();
                foreach (var item in _OriginalLostItemDataList)
                {
                    LostItemDataList.Add(item);
                }

                FoundItemDataList.Clear();
                foreach (var item in _OriginalFoundItemDataList)
                {
                    FoundItemDataList.Add(item);
                }
            }
        }
    }
}




