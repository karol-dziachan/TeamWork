namespace TeamWork.App.Abstract;

public interface IService<T> 
{
    List<T> Items { get; set; }

    List<T> GetAllItems();
    int GetLastId();
    T GetItemById(int id);
    int AddItem(T item);
    int UpdateItem(T item);
    int RemoveItem(T item);
    List<int> GetAllIds();

    void ShowAll();
}