using UTSLostAndFound.ViewModel;

namespace UTSLostAndFound.Views;

public partial class FavouritePage : ContentPage
{
    public FavouritePage()
    {
        InitializeComponent();
        BindingContext = new FavouriteViewModel();
    }
    private void SwipeItem_Invoked(object sender, EventArgs e)
    {

    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
    }
}