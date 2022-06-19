using TeamWork.App.Abstract;
using TeamWork.Domain.Common;

namespace TeamWork.App.Common;

public class BaseService<T> : IService<T> where T : BaseEntity
{
    public List<T> Items { get; set; }

    public BaseService()
    {
        Items = new List<T>();
    }
    
    public List<T> GetAllItems()
    {
        return Items;
    }

    public int GetLastId()
    {
        int lastId;

        if (Items.Any())
        {
            lastId = Items.OrderBy(item => item.Id).LastOrDefault().Id;
        }
        else
        {
            lastId = 0;
        }

        return lastId;
    }

    public T GetItemById(int id)
    {
        var entity = Items.FirstOrDefault(p => p.Id == id);
        return entity;
    }

    public int AddItem(T item)
    {
        Items.Add(item);
        return item.Id;
    }

    public int UpdateItem(T item)
    {
        int index = Items.FindIndex(s => s.Id == item.Id);

        if (index != -1)
            Items[index] =  item;
        
        return index;
    }

    public int RemoveItem(T item)
    {
        Items.Remove(item);

        return item.Id;
    }

    public List<int> GetAllIds()
    {
        List<int> ids = Items.Select(x => x.Id).ToList();
        
        return ids;
    }

    public virtual void ShowAll()
    {
        if (!Items.Any())
        {
            Console.WriteLine("No items");
        }
        else
        {
            foreach (var tmp in Items)
            {
                Console.WriteLine(tmp.ToString());
            }
        }
       
    }
    
}