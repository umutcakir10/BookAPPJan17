namespace BookAPP.Pages;

public partial class CommentPage : ContentPage
{
	public CommentPage()
	{
		InitializeComponent();
	}
    private async void geridönclicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}