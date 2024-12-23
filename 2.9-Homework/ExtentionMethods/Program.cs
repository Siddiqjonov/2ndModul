using ExtentionMethods.ExtentionMethods;
using System.Text;

namespace ExtentionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Even number");
            Console.Write("Enter: ");

            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 25));
            bool isEven = input.EvenNumber();
            Console.WriteLine("Even: " + isEven);

            Console.WriteLine(new string('-', 25));

            var isPrime = input.PrimeNumber();
            Console.WriteLine("Prime: " + isPrime);
            Console.WriteLine(new string('-', 25));

            Random random = new Random();
            var randomNumber = random.Next(1, 100);

            var adding = input.AddNumber(randomNumber);
            Console.WriteLine($"{input} + {randomNumber} = {adding}");
            Console.WriteLine(new string('-', 25));

            Console.Write("Enter any word: ");
            var word = Console.ReadLine();
            StringBuilder sb = new StringBuilder(word);
            int countOfUppers = sb.UpperLetterCount();
            Console.WriteLine("Count of upper letters: " + countOfUppers);
            Console.WriteLine(new string('-', 25));

            List<Person> persons = new List<Person>();
            Person person1 = new Person() { Name = "Aziz", Age = 34 };
            Person person2 = new Person() { Name = "Dilshod", Age = 43 };
            Person person3 = new Person() { Name = "Murod", Age = 93 };
            Person person4 = new Person() { Name = "Sarvar", Age = 76 };
            persons.Add(person1);
            persons.Add(person2);
            persons.Add(person3);
            persons.Add(person4);
            Person oldestPerson = persons.OldestPerson();
            Console.WriteLine($"Name: {oldestPerson.Name} \nAge: {oldestPerson.Age}");
            Console.WriteLine(new string('-', 25));


            List<Book> books = new List<Book>()
            {
                new Book() { Name = "Inferno", Price = 9.7m },
                new Book() { Name = "Frankenstein", Price = 19.9m },
                new Book() { Name = "Dune", Price = 4.6m },
                new Book() { Name = "Dust II", Price = 5.5m }
            };

            decimal totalPrice = books.TotalPrice();
            Console.WriteLine($"Total price: {totalPrice}");

            Console.ReadLine();
        }
    }
}
