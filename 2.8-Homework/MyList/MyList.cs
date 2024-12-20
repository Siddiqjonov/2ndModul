using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyList;

public class MyList<T> : IMyList<T>
{
    private T[] items;
    private int count;

    public MyList(int capasity)
    {
        items = new T[capasity];
        count = 0;
    }


    public MyList()
    {
        items = new T[4];
        count = 0;
    }

    public void AddItem(T item)
    {
        if (count == items.Length)
        {
            Resize();
        }
        items[count++] = item;
    }

    public T GetItemAt(int index)
    {
        CheckIndex(index);
        return items[index];
    }

    public T[] ToArray()
    {
        return items;
    }

    private void Resize()
    {
        var newItems = new T[items.Length * 2];
        for (int i = 0; i < count; i++)
        {
            newItems[i] = items[i];
        }
        items = newItems;
    }
    private void CheckIndex(int index)
    {
        if (0 > index || count <= index)
        {
            throw new IndexOutOfRangeException();
        }
    }

    public void RemoveItemAt(int index)
    {
        CheckIndex(index);
        for (int i = index; i < items.Length; i++)
        {
            if(i < count - 1)
                items[i] = items[i + 1];
        }
        count--;
        items[count] = default(T);
    }

    public void AddItemsRange(T[] nums)
    {
        //Resize();
        foreach (var num in nums)
        {
            AddItem(num);
        }
    }

    public void ReplaceAllItems(T oldElement, T newElement)
    {

        for (var i = 0; i < items.Length; i++)
        {
            if (object.Equals(items[i],oldElement))
            {
                items[i] = newElement;
            }
        }
    }

    public int GetItemIndex(T item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (object.Equals(items[i], item))
            {
                return i;
            }
        }
        return -1;
    }
    public int GetCount()
    {
        return count;
    }
    public int GetCapacity()
    {
        return items.Length;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (object.Equals((T)items[i], item))
            {
                return true;
            }
        }
        return false;
    }

    public void Clear()
    {
        Array.Clear(items);
    }

    public void InsertAt(int index, T item)
    {
        CheckIndex(index);
        var itemExists = Contains(item);
        if (!itemExists)
        {
            items[index] = item;
        }
        else
        {
            throw new Exception($"IndexIsTakenByOtherElement");
        }
    }

    public void Reverse()
    {
        T[] reverse = new T[items.Length];
        for (int i = 1;i <= items.Length; i++)
        {
            reverse[i - 1] = items[items.Length - i];
        }
        items = reverse;
        // Array.Reverse(items); This can also be used
    }

    public T[] GetRange(int startIndex, int amount)
    {
        CheckIndex(startIndex);
        var range = new T[amount];
        for (int i = 0; i < amount;i++)
        {
            range[i] = items[startIndex];
        }
        return range;
    }

    public void Sort()
    {
        Array.Sort(items);
    }
}
