
namespace BookAPP.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly BookService _bookService;
        public HomeViewModel(BookService bookService)
        {
            _bookService = bookService;
            Books = new(_bookService.GetPopularBooks());
        }

        public ObservableCollection<Book> Books { get; set; }

        [RelayCommand]
        private async Task GoToAllBooksPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllBookViewModel.FromSearch)] = fromSearch
            };
            await Shell.Current.GoToAsync(nameof(AllBooksPage), animate: true, parameters);
        }

        [RelayCommand]
        private async Task GoToDetailsPage(Book book)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Book)] = book
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}
