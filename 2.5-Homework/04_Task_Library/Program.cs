namespace _04_Task_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookCollection bookCollection = new BookCollection();
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("<< Welcome to library >>");
                Console.WriteLine(new string('-', 30));

                Console.WriteLine("0. Quit");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Read book");
                Console.WriteLine("3. Read all books");
                Console.WriteLine(new string('-', 30));

                Console.Write("Enter: ");
                var option = int.Parse(Console.ReadLine());
                Console.Clear();

                if (option == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Quiting...");
                    Console.ReadLine();
                    quit = true;
                }
                else if (option == 1)
                {
                    Book book = new Book();
                    Console.Write("Enter book title: ");
                    book.Title = Console.ReadLine();
                    Console.Write("Enter bool author: ");
                    book.Author = Console.ReadLine();
                    bookCollection.AddBook(book);
                    Console.WriteLine("Book added");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (option == 2)
                {
                    Console.Write("Enter author name: ");
                    var books = bookCollection.GetBooksByAuthor(Console.ReadLine());

                    if (books is null)
                    {
                        Console.WriteLine("No book is found");
                    }
                    else
                    {
                        foreach (Book book in books)
                        {
                            Console.WriteLine("Title: " + book.Title);
                            Console.WriteLine("Author: " + book.Author);
                        }
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (option == 3)
                {
                    var books = bookCollection.GetAllBooks();
                    foreach (Book book in books)
                    {
                        Console.WriteLine("Title: " + book.Title);
                        Console.WriteLine("Author: " + book.Author);
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Wrong option!!");
                    Console.WriteLine("Try again");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }

        }
    }
}
