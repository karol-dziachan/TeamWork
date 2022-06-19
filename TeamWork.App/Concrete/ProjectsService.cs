using TeamWork.App.Common;
using TeamWork.Domain.Entity;

namespace TeamWork.App.Concrete;

public class ProjectsService : BaseService<Project>
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

    public int AddOneTask(int projectId, int id)
    {
        var validateProject = GetItemById(projectId);

        if (validateProject == null)
        {
            Console.WriteLine("Wrong project id");
            return -1;
        }
        
        validateProject.Tasks.Add(id);

        return id;
    }

    public int RemoveTaskFromProjectByTaskId(int projectId, int taskId)
    {
        var validateProject = GetItemById(projectId);
        
        if (validateProject == null)
        {
            Console.WriteLine("Wrong project id");
            return -1;
        }

        int id = validateProject.Tasks.FindIndex(x => x == taskId);

        Console.WriteLine("id " + id);
        if (id != -1 && id < validateProject.Tasks.Capacity )
        {
            validateProject.Tasks.RemoveAt(id);

        }
        return id; 
    }

    public int GetProjectByTask(int taskId)
    {
         
        foreach (var item in Items)
        {
            List<int> projectId = item.Tasks.FindAll(x => x == taskId).ToList();

            if (projectId.Any())
            {
                var entity = item;
                return item.Id;
      
            }
        }

        return -1;
    }

    
}