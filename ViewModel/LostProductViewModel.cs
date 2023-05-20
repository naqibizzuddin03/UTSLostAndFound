using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class LostProductViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; private set; }

        public ObservableCollection<ProductListModel> LostProductDataList
        {
            get
            {
                return ItemData.LostItemDataList;
            }
        }

        public LostProductViewModel()
        {
            CommandInit();
        }

        private void CommandInit()
        {
            TapCommand = new Command<ProductListModel>(async (selectedItem) =>
            {
                await Shell.Current.Navigation.PushModalAsync(new ProductDetails(selectedItem));
            });
        }
    }
}
