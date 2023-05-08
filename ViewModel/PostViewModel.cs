
using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class PostViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand CreatePostCommand { get; private set; }

        public ObservableCollection<ProductListModel> AllProductDataList { get; set; }

        public PostViewModel()
        {
            AllProductDataList = new ObservableCollection<ProductListModel>();
            PopulateData();
            CommandInit();
        }

        void PopulateData()
        {
            AllProductDataList.Clear();
            AllProductDataList.Add(new ProductListModel() { Name = "Speekah", LastSeen = "Last seen:", Date = "01/03/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Rollex Ripoff", LastSeen = "Last seen:", Date = "26/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "ASMR device", LastSeen = "Last seen:", Date = "18/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Overpriced earbuds", LastSeen = "Last seen:", Date = "04/05/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
        }

        private void CommandInit()
        {
            TapCommand = new Command<ProductListModel>(items =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetails());
            });

            DeleteCommand = new Command<ProductListModel>(items =>
            {
                // Delete logic goes here
            });

            CreatePostCommand = new Command(CreateNewPost);
        }


        private void CreateNewPost()
        {
            // Logic for creating a new post goes here
            // This method will be invoked when the "Create New Post" button is tapped.
            Application.Current.MainPage = new CreateNewPostPage();
        }
    }
}
