
using System;
namespace BookAPP.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public event EventHandler<Book> CartItemRemoved;
        public event EventHandler<Book> CartItemUpdated;
        public event EventHandler CartCleared;

        public ObservableCollection<Book> Items { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;

        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

        [RelayCommand]
        private void UpdateCartItem(Book book)
        {
            var item = Items.FirstOrDefault(i => i.Name == book.Name);
            if (item is not null)
            {
                item.CartQuantity = book.CartQuantity;
            }
            else
            {
                Items.Add(book.Clone());
            }
            RecalculateTotalAmount();
        }

        [RelayCommand]
        private async void RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item is not null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();

                CartItemRemoved?.Invoke(this, item);

                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.PaleGoldenrod
                };
                var snackbar = Snackbar.Make($"'{item.Name}' sepetten çıkarıldı",
                    () =>
                    {
                        Items.Add(item);
                        RecalculateTotalAmount();
                        CartItemUpdated?.Invoke(this, item);
                    }, "Geri al", TimeSpan.FromSeconds(5), snackbarOptions);

                await snackbar.Show();
            }
        }

        [RelayCommand]
        private async Task ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Sepeti temizlemeyi onaylıyor musun?", "Gerçekten tüm ürünleri silmek istediğine emin misin?", "Evet", "Hayır"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                CartCleared?.Invoke(this, EventArgs.Empty);

                await Toast.Make("Sepet temizlendi", ToastDuration.Short).Show();
            }
        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            CartCleared?.Invoke(this, EventArgs.Empty);
            RecalculateTotalAmount();
            await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);
        }
    }
}