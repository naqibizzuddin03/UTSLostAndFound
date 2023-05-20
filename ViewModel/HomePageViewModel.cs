using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    //principle for inheritance is implemented in this viewmodel
    public class BaseHomePageViewModel : BaseViewModel
    {
        protected string _searchText;
        protected ObservableCollection<ProductListModel> _OriginalLostItemDataList;
        protected ObservableCollection<ProductListModel> _OriginalFoundItemDataList;

        public ObservableCollection<ProductListModel> LostItemDataList
        {
            get => ItemData.LostItemDataList;
        }

        public ObservableCollection<ProductListModel> FoundItemDataList
        {
            get => ItemData.FoundItemDataList;
        }

        protected void PopulateData()
        {
            // Clone the original lists
            _OriginalLostItemDataList = new ObservableCollection<ProductListModel>(LostItemDataList);
            _OriginalFoundItemDataList = new ObservableCollection<ProductListModel>(FoundItemDataList);
        }

        protected async void SelectCategory(CategoriesModel obj)
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

        protected async void GoToCreateNewPostPage()
        {
            await Shell.Current.Navigation.PushAsync(new CreateNewPostPage());
        }

        protected void SearchLostAndFoundItems(string searchText)
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

    public class HomePageViewModel : BaseHomePageViewModel
    {
        public ICommand TapCommand { get; private set; }
        public ICommand CategoryTapCommand { get; private set; }
        public ICommand IconTapCommand { get; private set; }

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
    }
}




