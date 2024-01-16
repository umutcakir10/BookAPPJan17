using BookApp.Models;

namespace BookAPP.Services
{
    public class BookService
    {
        private readonly static IEnumerable<Book> _Books = new List<Book>
        {
            new Book
            {
                Name = "Gurur ve Önyargı",
                Image = "gururveonyargi",
                Price = 5.1
            },
            new Book
            {
                Name = "Dörtlükler",
                Image = "dortlukler",
                Price = 2.5
            },
            new Book
            {
                Name = "Kitap3",
                Image = "duinoagitları",
                Price = 1.45
            },
            new Book
            {
                Name = "Geceye Övgüler",
                Image = "geceyeovguler",
                Price = 3.5
            },
            new Book
            {
                Name = "Gorgias",
                Image = "gorgias",
                Price = 2.99
            },
            new Book
            {
                Name = "Hüsn-ü Aşk",
                Image = "husnuask",
                Price = 5.1
            },
            new Book
            {
                Name = "Kanlı Düğün",
                Image = "kanlidugun",
                Price = 4.0
            },
            new Book
            {
                Name = "Kerem ile Aslı",
                Image = "keremileasli",
                Price = 9.25
            },
            new Book
            {
                Name = "Paris Sıkıntısı",
                Image = "parissikintisi",
                Price = 3.24
            },
            new Book
            {
                Name = "Yürek Burgusu",
                Image = "yurekburgusu",
                Price = 2.9
            }
        };

        public IEnumerable<Book> GetAllBooks() => _Books;

        public IEnumerable<Book> GetPopularBooks(int count = 6) =>
            _Books.OrderBy(p => Guid.NewGuid())
            .Take(count);

        public IEnumerable<Book> SearchBooks(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
            ? _Books
            : _Books.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}
