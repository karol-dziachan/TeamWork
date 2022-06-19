using TeamWork.Domain.Common;

namespace TeamWork.Domain.Entity;

public class Project : BaseEntity
{
    public int OwnerId { get; set; }
    public List<int> WorkersId { get; set; }
    public string Name { get; set; }
    public List<int> Tasks { get; set; }

    public Project()
    {
        
    }

    public Project(int id, string name)
    {
        Id = id;
        Name = name;
        OwnerId = 100;
        WorkersId = new List<int>() {1, 2, 3, 4};
        Tasks = new List<int>();
    }

    public Project(int id, int ownerId, List<int> workersId, string name,  List<int> tasks)
    {
        Id = id;
        OwnerId = ownerId;
        WorkersId = workersId;
        Name = name;
        Tasks = tasks;
    }

    public String ToString()
    {
        string tasks = "";

        if (Tasks.Any())
        {
            foreach (int task in Tasks)
            {
                tasks += task + " ";
            }
        }
        else
        {
            tasks = "Project has no tasks";
        }


        string workers = "";
        foreach (int worker in WorkersId)
        {
            workers += worker + " "; 
        }
        
        return $"Id: {Id}, Owner: {OwnerId}, Workers: {workers}, Name: {Name}, Tasks: {tasks}";
    }
}