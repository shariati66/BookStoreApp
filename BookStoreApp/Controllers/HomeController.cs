using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace BookStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<BookViewModel> _books = new List<BookViewModel>();
        private static string FilePath { get; set; } = "Books.json";
        private void SaveToFile(List<BookViewModel> book)
        {
            var json = JsonConvert.SerializeObject(book,Formatting.Indented);
            System.IO.File.WriteAllText(FilePath, json);
        }
        private List<BookViewModel> GetBooksFromFiles()
        {
            if (System.IO.File.Exists(FilePath))
            {
                var json = System.IO.File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<BookViewModel>>(json);
            }
            return new List<BookViewModel>();
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookViewModel book)
        {
            if(ModelState.IsValid)
            {
                book.Id = _books.Count > 0 ? _books.Max(x => x.Id) + 1 : 1;
                _books = GetBooksFromFiles();
                _books.Add(book);
                SaveToFile(_books);
                return View(nameof(Index));
            }
            return View();
        }
        public IActionResult ListOfBook(string bookName)
        {
            var books = GetBooksFromFiles();
            if (!string.IsNullOrEmpty(bookName))
            {
                books = books.Where(x => x.Name.Contains(bookName)).ToList();
            }
            return View(books);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
