using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethods.ExtentionMethods;

public static class ListExtentionMethod
{
    public static Person OldestPerson(this List<Person> persons)
    {
        //persons[0].Age > persons[1].Age ? persons[0] > persons[2]
        // 16 43 33 76
        var allAges = new int[persons.Count];
        for (int i = 0; i < persons.Count; i++)
        {
            allAges[i] = persons[i].Age;
        }
        Array.Sort(allAges);
        Array.Reverse(allAges);
        for (int i = 0; i < allAges.Length; i++)
        {
            if (persons[i].Age == allAges[0])
            {
                return persons[i];
            }
        }
        return null;
    }
    public static decimal TotalPrice(this List<Book> books)
    {
        decimal totalPrice = 0;
        foreach (var book in books)
        {
            totalPrice += book.Price;
        }
        return totalPrice;
    }
}
