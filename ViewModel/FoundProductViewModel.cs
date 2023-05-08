

using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class FoundProductViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; private set; }

        public ObservableCollection<FoundProductListModel> _FoundProductDataList = new ObservableCollection<FoundProductListModel>();
        public ObservableCollection<FoundProductListModel> FoundProductDataList
        {
            get
            {
                return _FoundProductDataList;
            }
            set
            {
                _FoundProductDataList = value;
                OnPropertyChanged("FoundProductDataList");
            }
        }

        public FoundProductViewModel()
        {
            PopulateData();
            CommandInit();
        }

        void PopulateData()
        {
            FoundProductDataList.Clear();
            FoundProductDataList.Add(new FoundProductListModel() { Name = "Speekah", LastSeen = "Last seen:", Date = "01/03/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            FoundProductDataList.Add(new FoundProductListModel() { Name = "Leather Wristwatch", LastSeen = "Last seen:", Date = "26/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            FoundProductDataList.Add(new FoundProductListModel() { Name = "ASMR device", LastSeen = "Last seen:", Date = "18/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            FoundProductDataList.Add(new FoundProductListModel() { Name = "Overpriced earbuds", LastSeen = "Last seen:", Date = "04/05/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
        }

        private void CommandInit()
        {
            TapCommand = new Command<FoundProductListModel>(items =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetails());
            });

        }
    }
}
