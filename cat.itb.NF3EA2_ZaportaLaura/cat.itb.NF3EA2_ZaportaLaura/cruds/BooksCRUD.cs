using System.Diagnostics;
using cat.itb.NF3EA2_ZaportaLaura.cruds.others;
using EA1.model.booksCollection;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace cat.itb.NF3EA2_ZaportaLaura.cruds
{
    public class BooksCRUD : Database
    {
        private static IMongoCollection<BsonDocument> _collection { get; set; } = _database.GetCollection<BsonDocument>("books");
        public static void LoadBooksCollection()
        {
            HelperClass.LoadCollectionArray<Book>("books", "Book");
        }
        public static void SelectTitlePagesAndCategoriesOfAll() // EX 2c
        {
            var books = _collection.Find(new BsonDocument()).ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"\n {book.GetElement("title")}" +
                    $"\n {book.GetElement("pageCount")}" +
                    $"\n {book.GetElement("categories")}\n");
            }
        }
        public static void SelectTitlePagesAndAuthorsByLessThanXPages(int pages) // EX 2f
        {
            var pagesFilter = Builders<BsonDocument>.Filter.Lt("pageCount", pages);
            var books = _collection.Find(pagesFilter).ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"\n {book.GetElement("title")}" +
                    $"\n {book.GetElement("pageCount")}" +
                    $"\n {book.GetElement("authors")}\n");
            }
        }
        public static void UpdateAddAuthorToTitle(string title, string author) // EX 3c
        {
            var settings = new JsonWriterSettings { Indent = true };

            var titleFilter = Builders<BsonDocument>.Filter.Eq("title", title);
            var update = Builders<BsonDocument>.Update.Push("authors", author);

            var bookToUpdate = _collection.Find(titleFilter).FirstOrDefault();
            Console.WriteLine($"\n Llibre a actualitzar: \n --------------------- \n {bookToUpdate.ToJson(settings)}");

            _collection.UpdateOne(titleFilter, update);

            var bookUpdated = _collection.Find(titleFilter).FirstOrDefault();
            Console.WriteLine($"\n Llibre actualitzat: \n ------------------- \n {bookUpdated.ToJson(settings)}");
        }
        public static void DeleteIfPagesInRange(int min, int max) // EX 4c
        {
            var boroughFilter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Gte("pageCount", min),
                Builders<BsonDocument>.Filter.Lte("pageCount", max)
                );

            var docsDeleted = _collection.DeleteMany(boroughFilter);
            Console.WriteLine($"\n Documents eliminats: {docsDeleted.DeletedCount}");
        }
        public static void DeleteLastCategoryFromXISBN(string isbn) // EX 4e
        {
            var settings = new JsonWriterSettings { Indent = true };

            var isbnFilter = Builders<BsonDocument>.Filter.Eq("isbn", isbn);
            var update = Builders<BsonDocument>.Update.PopLast("categories");

            var docToUpdate = _collection.Find(isbnFilter).FirstOrDefault();
            Console.WriteLine($"\n {docToUpdate.ToJson(settings)}");

            _collection.UpdateOne(isbnFilter, update);

            var docUpdated = _collection.Find(isbnFilter).FirstOrDefault();
            Console.WriteLine($"\n {docUpdated.ToJson(settings)}");
        }
    }
}