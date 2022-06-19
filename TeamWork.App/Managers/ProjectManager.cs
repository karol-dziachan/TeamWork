using TeamWork.App.Abstract;
using TeamWork.App.Concrete;
using TeamWork.Domain.Entity;
using Task = TeamWork.Domain.Entity.Task;

namespace TeamWork.App.Managers;

/*
 
   Console.WriteLine("10. Get project by id");
   Console.WriteLine("11. Update project");

   Console.WriteLine("13. Get project's tasks");
   Console.WriteLine("14. Get project by task");
 */

public class ProjectManager
{
    private TasksService _taskService;
    private IService<User> _userService;
    private ProjectsService _projectService;

    public ProjectManager(IService<Task> taskService, IService<User> userService, IService<Project> projectService)
    {
        _taskService = (TasksService) taskService;
        _userService = userService;
        _projectService = (ProjectsService) projectService;
        
        Seed();
    }

    private void Seed()
    {
        List<int> workersId = new List<int>();
        workersId.Add(1);
        workersId.Add(1);
        workersId.Add(1);

        List<int> tasksId2 = new List<int>();
        tasksId2.Add(1);
        tasksId2.Add(2);
        tasksId2.Add(3);
        tasksId2.Add(4);
        tasksId2.Add(5);
        tasksId2.Add(6);
        tasksId2.Add(7); 
        
        List<int> tasksId = new List<int>();

        _projectService.AddItem(new Project(1, 1, workersId, "Example", tasksId));
        _projectService.AddItem(new Project(2, 2, workersId, "Example1", tasksId2));
 
    }
    
    public  void ShowAllProjects()
    {
        Console.WriteLine();
        _projectService.ShowAll();
    }

    public int AddNewProject()
    {
        Console.WriteLine();
        Console.WriteLine("Enter the project name");
        string projectName = Console.ReadLine();
        
        int addedId = _projectService.GetLastId() + 1;
        _projectService.AddItem(new Project(addedId, projectName));
        
        return addedId;
    }

    public int CompletlyProjectRemove()
    {
        Console.WriteLine("Enter project id");
        int projectId;
        var projectIdInput = Console.ReadLine();
        Int32.TryParse(projectIdInput, out projectId);
        var validateProject = _projectService.GetItemById(projectId);

        if (validateProject == null)
        {
            Console.WriteLine("Project no found");
            return -1;
        }

        foreach (int task in validateProject.Tasks)
        {
            int validateTask = _taskService.RemoveProjectId(task);
            if (validateTask == -1)
            {
                return -1;
            }
        }
        
        int validate = _projectService.RemoveItem(validateProject);
        
        if (validate == -1)
        {
            return -1;
        }
        
        return validate;
    }

    public int GetProjectByTask()
    {
        Console.WriteLine("Enter the task id:");
        int taskId;
        var taskIdInput = Console.ReadLine();
        Int32.TryParse(taskIdInput, out taskId);
        var validateTask = _taskService.GetItemById(taskId);

        if (validateTask == null)
        {
            Console.WriteLine("Task no found");
            return -1;
        }

        int validateProject = _projectService.GetProjectByTask(taskId);

        return validateProject;
    }

    public int UpdateTheProject()
    {
        throw new NotImplementedException();
    }

    
    
}