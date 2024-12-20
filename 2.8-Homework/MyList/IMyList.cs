namespace MyList;

public interface IMyList<T>
{
    void AddItem(T item); // 1
    T GetItemAt(int index); // 2
    void RemoveItemAt(int index); // 3
    void AddItemsRange(T[] nums); // 4
    void ReplaceAllItems(T oldElement, T newElement); // 5
    int GetItemIndex(T item); // 6
    int GetCount(); // 7
    int GetCapacity(); // 8
    public T[] ToArray(); // 9
    bool Contains(T item); // start // 10
    void Clear(); // 11
    void InsertAt(int index, T item); // 12
    void Reverse(); // 13
    T[] GetRange(int startIndex, int amount); // 14
    void Sort(); // 15
}