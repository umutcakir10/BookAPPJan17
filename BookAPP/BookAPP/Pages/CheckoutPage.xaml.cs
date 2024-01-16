namespace BookAPP.Pages;

public partial class CheckoutPage : ContentPage
{
    public CheckoutPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        
        msg.ScaleTo(1);

        

        homeBtn.FadeTo(1, length: 500);
        await homeBtn.ScaleTo(1);
    }

    async void homeBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}", animate: true);
    }
}