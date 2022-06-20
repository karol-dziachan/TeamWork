using TeamWork.App.Abstract;
using TeamWork.App.Concrete;
using TeamWork.Domain.Entity;
using Task = TeamWork.Domain.Entity.Task;

namespace TeamWork.App.Managers;

/* przy dodawaniu taska dopisac go do tablicy w projekcie
 */
public class TaskManager
{
    private TasksService _taskService;
    private IService<User> _userService;
    private ProjectsService _projectService;

    public TaskManager(IService<Task> taskService, IService<User> userService, IService<Project> projectService)
    {
        _taskService = (TasksService) taskService;
        _userService = userService;
        _projectService = (ProjectsService) projectService;
        
        Seed();
    }

    public int AddNewTask()
    {
        Console.WriteLine();
        Console.WriteLine("Enter the task name");
        string taskName = Console.ReadLine();
        
        Console.WriteLine("Enter the task description");
        string taskDescription = Console.ReadLine();
        
        Console.WriteLine("Enter the task deadline");
        string taskDeadline = Console.ReadLine();

        int addedId = _taskService.GetLastId() + 1; 
        
        _taskService.AddItem(new Task(addedId, taskDescription, taskName, taskDeadline));

        return addedId;
    }

    public void GetTaskById()
    {
        Console.WriteLine("Enter task id");
        int taskId;
        var taskIdInput = Console.ReadLine();
        Int32.TryParse(taskIdInput, out taskId);
        var validateTask = _taskService.GetItemById(taskId);

        if (validateTask == null)
        {
            Console.WriteLine("Task no found");
            return;
        }
        
        Console.WriteLine(validateTask.ToString());
    }

    public int UpdateTheTask()
    {
        _taskService.ShowAll();
        Console.WriteLine("Which task do you want update?");
        int taskId;
        var taskIdInput = Console.ReadLine();
        Int32.TryParse(taskIdInput, out taskId);
        var validateTask = _taskService.GetItemById(taskId);

        if (validateTask == null)
        {
            Console.WriteLine("Task no found");
            return -1;
        }
        
        Console.WriteLine("Enter user id");        
        int userId;
        var userIdInput = Console.ReadLine();
        Int32.TryParse(userIdInput, out userId);
        var validateUser = _userService.GetItemById(userId);

        if (validateUser == null)
        {
            Console.WriteLine("User no found");
            return -1;
        }
        
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
        
      
        
        Console.WriteLine("Enter the task name");
        string taskName = Console.ReadLine();
        
        Console.WriteLine("Enter the task description");
        string taskDescription = Console.ReadLine();
        
        Console.WriteLine("Enter the task deadline");
        string taskDeadline = Console.ReadLine();

        Task task = new Task(taskId, userId, projectId, taskDescription, taskName, taskDeadline);
        int updatedId = _taskService.UpdateItem(task);

        int parentProject = _projectService.GetProjectByTask(taskId);
        _projectService.RemoveTaskFromProjectByTaskId(parentProject, taskId);
        _projectService.AddOneTask(projectId, taskId);
        

        return updatedId;
    }

    public int AssignTaskToTheProject()
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
        
        Console.WriteLine("Enter task id");
        int taskId;
        var taskIdInput = Console.ReadLine();
        Int32.TryParse(taskIdInput, out taskId);
        var validateTask = _taskService.GetItemById(taskId);

        if (validateTask == null)
        {
            Console.WriteLine("Task no found");
            return -1;
        }

        RemoveProjectTask(_projectService.GetProjectByTask(taskId), taskId);
        
        int validateReturn = _projectService.AddOneTask(projectId, taskId);
        if (validateReturn == -1)
        {
            return -1;
        }

        int validateReturnTask = _taskService.UpdateProjectId(projectId, taskId);
        if (validateReturnTask == -1)
        {
            return -1;
        }
   
        return validateReturnTask;
    }

    public int RemoveProjectTask()
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

        Console.WriteLine("Enter task id");
        int taskId;
        var taskIdInput = Console.ReadLine();
        Int32.TryParse(taskIdInput, out taskId);
        var validateTask = _taskService.GetItemById(taskId);

        if (validateTask == null)
        {
            Console.WriteLine("Task no found");
            return -1;
        }

        var validateProjectId = _projectService.RemoveTaskFromProjectByTaskId(projectId, taskId);
        if (validateProjectId == -1)
        {
            return -1;
        }

        var validateTaskId = _taskService.RemoveProjectId(taskId);
        if (validateProjectId == -1)
        {
            return -1;
        }

        return validateTaskId;
    } 
    
    private int RemoveProjectTask(int projectId, int taskId)
    {
        
        var validateProjectId = _projectService.RemoveTaskFromProjectByTaskId(projectId, taskId);
        if (validateProjectId == -1)
        {
            return -1;
        }

        var validateTaskId = _taskService.RemoveProjectId(taskId);
        if (validateProjectId == -1)
        {
            return -1;
        }

        return validateTaskId;
    }

    public int CompletlyTaskRemove()
    {
        Console.WriteLine("Enter task id");
        int taskId;
        var taskIdInput = Console.ReadLine();
        Int32.TryParse(taskIdInput, out taskId);
        var validateTask = _taskService.GetItemById(taskId);

        if (validateTask == null)
        {
            Console.WriteLine("Task no found");
            return -1;
        }

        int validate = _taskService.RemoveItem(validateTask);
        
        if (validate == -1)
        {
            return -1;
        }

        if (validateTask.ProjectId != -1)
        {
            _projectService.RemoveTaskFromProjectByTaskId(validateTask.ProjectId, taskId);
        }
        
       

        return validate;

    }

    public void ShowAllTasks()
    {
        Console.WriteLine();
        _taskService.ShowAll();
    }

    private void Seed()
    {
        _taskService.AddItem(new Task(1, 2, 2, "This is example description", "This is example name", "2020.05.20"));
        _taskService.AddItem(new Task(2, 2, 2, "This is example description", "This is example name", "2020.05.20"));
        _taskService.AddItem(new Task(3, 2, 2, "This is example description", "This is example name", "2020.05.20"));
        _taskService.AddItem(new Task(4, 2, 2, "This is example description", "This is example name", "2020.05.20"));
        _taskService.AddItem(new Task(5, 2, 2, "This is example description", "This is example name", "2020.05.20"));
        _taskService.AddItem(new Task(6, 2, 2, "This is example description", "This is example name", "2020.05.20"));
        _taskService.AddItem(new Task(7, 2, 2, "This is example description", "This is example name", "2020.05.20"));

    }
    
}