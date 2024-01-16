namespace BookAPP.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
            string.IsNullOrWhiteSpace(SurnameEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordConfirmEntry.Text))
        {
            MessageLabel.Text = "Lütfen tüm alanlarý doldurun.";
            return;
        }

        if (PasswordEntry.Text != PasswordConfirmEntry.Text)
        {
            MessageLabel.Text = "Parolalar eþleþmiyor.";
            return;
        }

        
        MessageLabel.Text = "Kayýt baþarýlý!";

        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}