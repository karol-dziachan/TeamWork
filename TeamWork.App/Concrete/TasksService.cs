using TeamWork.App.Common;
using Task = TeamWork.Domain.Entity.Task;

namespace TeamWork.App.Concrete;

public class TasksService : BaseService<Task>
{
    public override void ShowAll()
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

    public int UpdateProjectId(int projectId, int taskId)
    {
        var validateTask = GetItemById(taskId);

        if (validateTask == null)
        {
            Console.WriteLine("Wrong task id");
            return -1;
        }
        
        validateTask.ProjectId = projectId;

        return taskId;
    } 
    
    public int RemoveProjectId(int taskId)
    {
        var validateTask = GetItemById(taskId);

        if (validateTask == null)
        {
            Console.WriteLine("Wrong task id");
            return -1;
        }
        
        validateTask.ProjectId = -1;

        return taskId;
    }
    
    
}