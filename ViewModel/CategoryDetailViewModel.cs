using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class CategoryDetailViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; private set; }

        public ObservableCollection<ProductListModel> CategoryProductDataList { get; }

        public CategoryDetailViewModel(ObservableCollection<ProductListModel> categoryProductDataList)
        {
            CategoryProductDataList = categoryProductDataList;
            CommandInit();
        }

        private void CommandInit()
        {
            TapCommand = new Command<ProductListModel>(items =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetails(items));
            });
        }
    }
}


