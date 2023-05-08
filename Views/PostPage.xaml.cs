using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class PostPage : ContentPage
{
    public PostPage()
    {
        InitializeComponent();
        BindingContext = new PostViewModel();
    }
    private void SwipeItem_Invoked(object sender, EventArgs e)
    {

    }
}