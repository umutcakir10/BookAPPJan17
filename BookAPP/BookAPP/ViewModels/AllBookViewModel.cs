
namespace BookAPP.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllBookViewModel : ObservableObject
    {
        private readonly BookService _bookService;
        public AllBookViewModel(BookService bookService)
        {
            _bookService = bookService;
            Books = new(_bookService.GetAllBooks());
        }
        public ObservableCollection<Book> Books { get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _searching;

        [RelayCommand]
        private async Task SearchBooks(string searchTerm)
        {
            Books.Clear();
            Searching = true;
            await Task.Delay(1000);
            foreach (var book in _bookService.SearchBooks(searchTerm))
            {
                Books.Add(book);
            }
            Searching = false;
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