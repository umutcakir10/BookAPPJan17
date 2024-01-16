using BookAPP.Models;

namespace BookAPP.Services
{
    public class BookService
    {
        private readonly static IEnumerable<Book> _Books = new List<Book>
        {
            new Book
            {
                Name = "Gurur ve Önyargı",
                Image = "gururveonyargi.png",
                Price = 80.50,
                Description = "Jane Austen'ın cesaretini ve hiciv yeteneğini gözler önüne seren bu roman, 19. yüzyıldaki sınıfsal farklılıkları ve kadınların hapsedildiği ataerkil bakış açısını bir ailenin yaşamı üzerinden analiz ediyor."
            },
            new Book
            {
                Name = "Dörtlükler",
                Image = "dortlukler.png",
                Price = 74.60,
                Description = " Günümüzde ise, daha çok \"rubai\" türünün yaratıcısı olarak kabul gören Hayyam'ın dörtlükleri, Türkçe'ye Yahya Kemal ve Abdülbaki Gölpınarlı başta olmak üzere pek çok kez çevrildi. Sabahattin Eyüboğlu'nun çevirisi de, bunlar arasında en sevilenlerinden biri."

            },
            new Book
            {
                Name = "Duino Ağıtları",
                Image = "duinoagitlari.png",
                Price = 77.50,
                Description = " Yaşama arzusunun ve ölüm korkusunun dokunaklı bir dille şiire döküldüğü Duino Ağıtları Rilke’ye sadık, yepyeni bir çeviriyle bir kez daha okurla buluşuyor."
            },
            new Book
            {
                Name = "Geceye Övgüler",
                Image = "geceyeovguler.png",
                Price = 65.50,
                Description = "Sophie von Kühn'ün ölümünün ardından yazdığı Geceye Övgüler (1800) dünya edebiyatında toplumsal ve bireysel acıların keskin bir duyarlıkla dile getirilişinin en çarpıcı örneklerindendir. "
            },
            new Book
            {
                Name = "Gorgias",
                Image = "gorgias.png",
                Price = 88.90,
                Description = "Kallikles - Sizin yaptığınız gibi, ancak savaşa ve kavgaya geç katılabilir insan, Sokrates. Atasözü de böyle der.Sokrates - Yoksa, denildiği gibi, şölenden sonra mı geldik? Geç mi kaldık acaba?"
            },
            new Book
            {
                Name = "Hüsn-ü Aşk",
                Image = "husnuask.png",
                Price = 60.99,
                Description = "Şeyh Galib (1757-1799): Sadece 23 yaşında \"tertib ettiği\" Divan'ının (1780) yanı sıra iki yıl sonra yazdığı Hüsn ü Aşk (İyilik ve Aşk) adlı mesnevisiyle de Dîvan Edebiyatı'nın son büyük ustası olarak adlandırılan 18. yüzyıl şairidir."
            },
            new Book
            {
                Name = "Kanlı Düğün",
                Image = "kanlidugun.png",
                Price = 59.99,
                Description = "Onu oyun yazarı olarak da kabul ettiren en önemli yapıtlarından Kanlı Düğün'se (1933), yazılışından 73 yıl sonra Türkçe'ye ilk kez özgün dilinden çevrilmektedir."
            },
            new Book
            {
                Name = "Kerem ile Aslı",
                Image = "keremileasli.png",
                Price = 63.25,
                Description = "Kerem ile Aslı temel yapısının 16. yüzyılda Kerem Dede ya da Âşık Kerem adlı bir âşığın şiirleriyle oluştuğu sanılan ve günümüzde de halk anlatıları arasında en iyi bilinenlerden biridir. "
            },
            new Book
            {
                Name = "Emma",
                Image = "emma.png",
                Price = 89.90,
                Description = "1815'te yayımlanan Jane Austen'ın dördüncü romanı Emma on dokuzuncu yüzyıl İngiltere'sinde evlilik ve sosyal statüyü hicvederek irdeler."
            },
            new Book
            {
                Name = "Yürek Burgusu",
                Image = "yurekburgusu.png",
                Price = 84.50,
                Description = "Orta döneminin en önemli yapıtlarından olan Yürek Burgusu'nun (1898) ürperticiliği de, bir yandan bir \"hayalet\" öyküsü olmasından ama bir okadar da, James'in, sayfalar çevrildikçe yüreğimize işleyen üslubundan kaynaklanmaktadır."
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
