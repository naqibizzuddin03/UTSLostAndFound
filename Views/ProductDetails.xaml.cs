using UTSLostAndFound.Model;
using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetails : ContentPage
    {
        public ProductDetails(ProductListModel selectedItem)
        {
            InitializeComponent();
            BindingContext = new ProductDetailsViewModel(selectedItem);
        }
    }
}