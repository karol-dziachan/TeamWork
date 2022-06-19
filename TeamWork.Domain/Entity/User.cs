using TeamWork.Domain.Common;

namespace TeamWork.Domain.Entity;

public class User : BaseEntity
{
    public string UserName { get; set; }

    public User()
    {
        
    }

    public User(int id, string userName)
    {
        Id = id;
        UserName = userName;
    }
}