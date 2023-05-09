using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class YourPostPage : ContentPage
{
    public YourPostPage()
    {
        InitializeComponent();
        BindingContext = new YourPostViewModel();
    }
    private void SwipeItem_Invoked(object sender, EventArgs e)
    {

    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
    }
}