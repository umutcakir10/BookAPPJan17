namespace BookAPP.Pages;

public partial class AllBooksPage : ContentPage
{
    private readonly AllBookViewModel _allBookViewModel;
    public AllBooksPage(AllBookViewModel allBookViewModel)
    {
        InitializeComponent();
        _allBookViewModel = allBookViewModel;
        BindingContext = _allBookViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_allBookViewModel.FromSearch)
        {
            await Task.Delay(200);
            searchBar.Focus();
        }
    }

    void searchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.OldTextValue)
            && string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            _allBookViewModel.SearchBooksCommand.Execute(null);
        }
    }
}