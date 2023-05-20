using System.Collections.ObjectModel;
using UTSLostAndFound.Model;
using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryDetail : ContentPage
    {
        public CategoryDetail(ObservableCollection<ProductListModel> categoryProductDataList)
        {
            InitializeComponent();
            BindingContext = new CategoryDetailViewModel(categoryProductDataList);
        }
    }
}
