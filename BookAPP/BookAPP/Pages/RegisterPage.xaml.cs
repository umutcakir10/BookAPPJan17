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
            MessageLabel.Text = "L�tfen t�m alanlar� doldurun.";
            return;
        }

        if (PasswordEntry.Text != PasswordConfirmEntry.Text)
        {
            MessageLabel.Text = "Parolalar e�le�miyor.";
            return;
        }

        
        MessageLabel.Text = "Kay�t ba�ar�l�!";

        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}