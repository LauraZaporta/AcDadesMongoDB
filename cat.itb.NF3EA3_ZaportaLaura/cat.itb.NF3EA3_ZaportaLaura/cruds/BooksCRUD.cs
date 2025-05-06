using System.Linq;
using cat.itb.NF3EA3_ZaportaLaura.cruds.others;
using cat.itb.NF3EA3_ZaportaLaura.model;
using EA1.connections;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace cat.itb.NF3EA3_ZaportaLaura.cruds
{
    public class BooksCRUD : Database
    {
        public static void LoadBooksObjectCollection()
        {
            FileInfo file = new FileInfo("../../../files/books.json");
            StreamReader sr = file.OpenText();
            string fileString = sr.ReadToEnd();
            sr.Close();
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(fileString);

            _database.DropCollection("books");

            var collection = _database.GetCollection<Book>("books");

            if (books != null)
                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                    collection.InsertOne(book);
                }
        }
        public static void SelectTitleAuthorsAndPageCountByRangePagesAndCategory(int min, int max, string category)
        {
            IMongoCollection<Book2> collection = _database.GetCollection<Book2>("books");

            var query = collection.AsQueryable<Book2>();

            var books = query.Where(b => b.PageCount >= min && b.PageCount <= max && b.Categories.Contains(category)).ToList();

            foreach (Book2 book in books)
            {
                Console.WriteLine($"\n Títol: {book.Title}" +
                    $"\n Authors: {string.Join(", ", book.Authors)}" +
                    $"\n PageCount: {book.PageCount}");
            }
        }
        public static void SelectTitleAndAuthorsByAuthors(string[] authors)
        {
            IMongoCollection<Book2> collection = _database.GetCollection<Book2>("books");

            var query = collection.AsQueryable<Book2>();

            var books = query.Where(b => authors.All(author => b.Authors.Contains(author))).ToList();

            foreach (Book2 book in books)
            {
                Console.WriteLine($"\n Títol: {book.Title}" +
                    $"\n Authors: {string.Join(", ", book.Authors)}");
            }
        }
        public static void SelectTitleAndStatus()
        {
            IMongoCollection<Book2> collection = _database.GetCollection<Book2>("books");

            var query = collection.AsQueryable<Book2>();

            var books = query.Select(b => new { b.Title, b.Status }).ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"\n Títol: {book.Title}" +
                    $"\n Estatus: {book.Status}");
            }
        }
        public static void SelectTitleAndCategoriesDescPages()
        {
            IMongoCollection<Book2> collection = _database.GetCollection<Book2>("books");

            var query = collection.AsQueryable<Book2>();

            var books = query.OrderByDescending(b => b.PageCount);

            foreach (Book2 book in books)
            {
                Console.WriteLine($"\n Títol: {book.Title}" +
                    $"\n Authors: {string.Join(", ", book.Categories)}");
            }
        }
        public static void SelectIfContainsCategoryButNotXAuthorAscTitle(string category, string author)
        {
            IMongoCollection<Book2> collection = _database.GetCollection<Book2>("books");

            var query = collection.AsQueryable<Book2>();

            var books = query.Where(b => b.Categories.Contains(category) && !b.Authors.Contains(author)).OrderBy(b => b.Title).ToList();
            foreach (Book2 book in books)
            {
                Console.WriteLine($"\n {book.ToString()}");
            }
        }
    }
}