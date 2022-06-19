using TeamWork.Domain.Common;

namespace TeamWork.Domain.Entity;

public class Task : BaseEntity
{
    public int UserId { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Deadline { get; set; }
    
    public Task()
    {
        
    }

    public Task(int id, string description, string name, string deadline)
    {
        Id = id;
        Description = description;
        Name = name;
        Deadline = deadline;
    }
    
    public Task(int id, int projectId, string description, string name, string deadline) : this(id, description, name, deadline)
    {
        ProjectId = projectId;
    } 
    
    public Task(int id, string description, string name, string deadline, int userId) : this(id, description, name, deadline)
    {
        UserId = userId;
    }
    
    public Task(int id, int userId, int projectId, string description, string name, string deadline)
    {
        Id = id;
        UserId = userId;
        ProjectId = projectId;
        Description = description;
        Name = name;
        Deadline = deadline;
    }  

    public string ToString()
    {
        return $"Id: {Id}, UserId: {UserId}, ProjectId: {ProjectId}, Name: {Name}, Description: {Description}, Deadline: {Deadline}";
    }
    
}