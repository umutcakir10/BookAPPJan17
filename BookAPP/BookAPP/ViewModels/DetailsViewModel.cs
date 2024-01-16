using System;


namespace BookAPP.ViewModels
{
    [QueryProperty(nameof(Book), nameof(Book))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;

            _cartViewModel.CartCleared += OnCartCleared;
            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;
        }

        private void OnCartCleared(object? _, EventArgs e) => Book.CartQuantity = 0;

        private void OnCartItemRemoved(object? _, Book p) =>
            OnCartItemChanged(p, 0);

        private void OnCartItemUpdated(object? _, Book p) =>
            OnCartItemChanged(p, p.CartQuantity);

        private void OnCartItemChanged(Book p, int quantity)
        {
            if (p.Name == Book.Name)
            {
                Book.CartQuantity = quantity;
            }
        }

        [ObservableProperty]
        private Book _book;

        [RelayCommand]
        private void AddToCart()
        {
            Book.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Book);
        }

        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Book.CartQuantity > 0)
            {
                Book.CartQuantity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Book);
            }
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if (Book.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Toast.Make("Lütfen miktar artırmak için yukarı tuşuna basın", ToastDuration.Short)
                    .Show();
            }
        }

        public void Dispose()
        {
            _cartViewModel.CartCleared -= OnCartCleared;
            _cartViewModel.CartItemRemoved -= OnCartItemRemoved;
            _cartViewModel.CartItemUpdated -= OnCartItemUpdated;
        }
    }
}