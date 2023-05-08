using UTSLostAndFound.Model;
using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class CategoryDetail : ContentPage
{
    public CategoryDetail(CategoriesModel data)
    {
        InitializeComponent();
        BindingContext = new CategoryDetailViewModel(data);
    }
}