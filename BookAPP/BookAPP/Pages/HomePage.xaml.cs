namespace BookAPP.Pages;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _homeViewModel;
    public HomePage(HomeViewModel homeViewModel)
    {
        InitializeComponent();
        _homeViewModel = homeViewModel;
        BindingContext = _homeViewModel;
    }
    private async void commentpageclicked(object sender, EventArgs e)
    {
       
        await Shell.Current.GoToAsync($"//{nameof(CommentPage)}");
    }
}