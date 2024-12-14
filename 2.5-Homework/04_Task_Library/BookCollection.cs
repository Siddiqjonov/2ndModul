using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _04_Task_Library
{
    public class BookCollection
    {
        private List<Book> _books;
        private string libraryFilePath;
        public BookCollection()
        {
            libraryFilePath = "../../../Books/Library.json";
            if (File.Exists(libraryFilePath) is false)
            {
                File.WriteAllText(libraryFilePath, "[]");
            }
            _books = new List<Book>();
            _books = GetAllBooks();
        }
        public void AddBook(Book book)
        {
            _books.Add(book);
            SavaData();
        }

        private void SavaData()
        {
            var booksJson = JsonSerializer.Serialize(_books);
            File.WriteAllText(libraryFilePath, booksJson);
        }

        public List<Book> GetAllBooks()
        {
            var saveBooksAsString = File.ReadAllText(libraryFilePath);
            var booksObj = JsonSerializer.Deserialize<List<Book>>(saveBooksAsString);
            return booksObj;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            var saveBooksAsString = File.ReadAllText(libraryFilePath);
            var booksObj = JsonSerializer.Deserialize<List<Book>>(saveBooksAsString);
            var books = new List<Book>();
            foreach (var book in booksObj)
            {
                if (book.Author == author)
                {
                    books.Add(book);
                }
            }
            if (books != null)
            {
                return books;
            }
            return null;
        }
    }
}
