using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    //polymorphism is implemented here by utilizing the ISelectableItem interface
    public interface ISelectableItem
    {
        ICommand TapCommand { get; }
        ICommand DeleteCommand { get; }
    }

    public class YourPostViewModel : BaseViewModel, ISelectableItem
    {
        public ICommand TapCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public ObservableCollection<ProductListModel> AllProductDataList { get; } = new ObservableCollection<ProductListModel>();

        public YourPostViewModel()
        {
            PopulateData();
            CommandInit();
        }

        void PopulateData()
        {
            foreach (var lostItem in ItemData.LostItemDataList)
            {
                AllProductDataList.Add(lostItem);
            }

            foreach (var foundItem in ItemData.FoundItemDataList)
            {
                AllProductDataList.Add(foundItem);
            }
        }

        private void CommandInit()
        {
            TapCommand = new Command<ProductListModel>(items =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetails(items));
            });

            DeleteCommand = new Command<ProductListModel>(item =>
            {
                if (item != null)
                {
                    AllProductDataList.Remove(item);

                    // Remove the item from the ItemData model
                    if (ItemData.LostItemDataList.Contains(item))
                    {
                        ItemData.LostItemDataList.Remove(item);
                    }
                    else if (ItemData.FoundItemDataList.Contains(item))
                    {
                        ItemData.FoundItemDataList.Remove(item);
                    }
                }
            });
        }
    }
}
