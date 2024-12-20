using System.Collections.Generic;
using System.Net.WebSockets;

namespace MyList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<string> list = new MyList<string>();
            //list.AddItem(34);
            //list.AddItem(56);
            //list.AddItem(3);
            //list.AddItem(4);
            //list.AddItem(334);
            //list.AddItem(134);
            //list.AddItem(23);
            //list.AddItem(14);
            //list.AddItem(74);

            Console.WriteLine("<< AddItem method 1 >>");
            list.AddItem("English");
            list.AddItem("Spanish");
            list.AddItem("French");
            list.AddItem("Italian");
            list.AddItem("Portuguese");
            list.AddItem("German");
            list.AddItem("Russian");
            list.AddItem("Arabic");
            list.AddItem("Japanese");
            Console.WriteLine();

            Console.WriteLine("<< ToArray method 2 >>");
            ShowAllElements(list);
            Console.WriteLine();

            Console.WriteLine("<< GetCapacity and GetCount methods 3,4 >>");
            Console.WriteLine($"Capacity: {list.GetCapacity()}");
            Console.WriteLine($"Count: {list.GetCount()}");
            Console.WriteLine();

            Console.WriteLine("<< GetItemIndex method 5 >>");
            Console.Write("Enter an element from the list: ");
            var element = Console.ReadLine();
            Console.WriteLine($"Index: {list.GetItemIndex(element)}");
            Console.WriteLine();


            Console.WriteLine("<< ReplaceAllItems method 6 >>");
            Console.Write($"Enter old element: ");
            var oldElement = Console.ReadLine();
            Console.Write($"Enter new elemrnt: ");
            var newElement = Console.ReadLine();
            list.ReplaceAllItems(oldElement, newElement);
            Console.WriteLine();

            ShowAllElements(list);
            Console.WriteLine();

            Console.WriteLine("<< AddItemsRange method 7 >>");
            var newNums = new string[3] { "Chinies", "Uzbek", "Tajik" };
            list.AddItemsRange(newNums);
            ShowAllElements(list);
            Console.WriteLine();

            Console.WriteLine("<< GetItemAt method 8 >>");
            Console.Write("Enter an index to get the element: ");
            Console.WriteLine($"Element: {list.GetItemAt(int.Parse(Console.ReadLine()))}");
            Console.WriteLine();

            Console.WriteLine("<< GetItemIndex method 9 >>");
            Console.Write("Enter a element to get the index: ");
            var item = Console.ReadLine();
            Console.WriteLine($"Index: {list.GetItemIndex(item)}");
            Console.WriteLine();

            Console.WriteLine("<< Contains method 10 >>");
            Console.Write("Contains: ");
            var contains = Console.ReadLine();
            Console.WriteLine("Contains: " + list.Contains(contains));
            Console.WriteLine();

            Console.WriteLine("<< GetRange method 11>>");
            Console.Write("Enter start index to get renge: ");
            var startIndex = int.Parse(Console.ReadLine());
            Console.Write("Enter numbers of elements: ");
            var count = int.Parse(Console.ReadLine());
            var items = list.GetRange(startIndex, count);
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{items[i]}, ");
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("<< InsertAt method 12>>");
            Console.Write("Enter an index to insert: ");
            var indexForInsert = int.Parse(Console.ReadLine());
            Console.Write("Enter numbers of elements: ");
            var itemForInsert = Console.ReadLine();
            list.InsertAt(indexForInsert, itemForInsert);
            ShowAllElements(list);
            Console.WriteLine();


            Console.WriteLine("<< Reverse method 13>>");
            list.Reverse();
            ShowAllElements(list);
            Console.WriteLine();

            Console.WriteLine("<< Sort method 14>>");
            list.Sort();
            ShowAllElements(list);
            Console.WriteLine();

            Console.WriteLine("<< RemoveItemAt method 15 >>");
            Console.Write("Enter an index of an element to remove: ");
            var index = int.Parse(Console.ReadLine());
            list.RemoveItemAt(index);
            ShowAllElements(list);
            Console.WriteLine();

            Console.WriteLine("<< Clear method 16 >>");
            list.Clear();
            Console.WriteLine("List is cleared");
            ShowAllElements(list);
            Console.WriteLine();

            Console.ReadLine();
        }
        public static void ShowAllElements(MyList<string> list)
        {
            var items = list.ToArray();
            Console.Write("Elements: ");
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write($"{items[i]}, ");
            }
            Console.WriteLine();
        }
    }
}
