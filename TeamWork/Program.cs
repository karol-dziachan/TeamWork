// See https://aka.ms/new-console-template for more information

using TeamWork.App.Concrete;
using TeamWork.App.Managers;

Console.WriteLine("Hello");

ProjectsService projectsService = new ProjectsService();
TasksService tasksService = new TasksService();
UserService userService = new UserService();

UserManager userManager = new UserManager(userService);
ProjectManager projectManager = new ProjectManager(tasksService, userService, projectsService);
TaskManager taskManager = new TaskManager(tasksService, userService, projectsService );

while (true)
{ 
    Console.WriteLine("Chose action:");
   Console.WriteLine("---------- TASKS ---------");
   Console.WriteLine("1. Add task");
   Console.WriteLine("2. Remove task");
   Console.WriteLine("3. Get task by id");
   Console.WriteLine("4. Update task");
   Console.WriteLine("5. Show all tasks");
   Console.WriteLine("6. Assign a task to the project");
   Console.WriteLine("7. Remove a task to the project");
   Console.WriteLine("---------- PROJECT ---------");
   Console.WriteLine("8. Add project");
   Console.WriteLine("9. Remove project");
   Console.WriteLine("10. Get project by id");
   Console.WriteLine("11. Update project");
   Console.WriteLine("12. Show all projects");
   Console.WriteLine("13. Get project's tasks");
   Console.WriteLine("14. Get project by task");
   
   
      var choice = Console.ReadLine();
 
     switch (choice)
     {
         case "1":
             var addedId = taskManager.AddNewTask();
             Console.WriteLine("Added id: " + addedId);
             break;
         case "2":
             var removedTaskId = taskManager.CompletlyTaskRemove();
             Console.WriteLine("Removed id: " + removedTaskId);
             break;
         case "3":
             taskManager.GetTaskById();
             break;
         case "4":
             var updatedTaskid = taskManager.UpdateTheTask();
             Console.WriteLine("Updated id: " + updatedTaskid);
             break;
         case "5":
             taskManager.ShowAllTasks();
             break;
         case "6":
             var assignedTask = taskManager.AssignTaskToTheProject();
             Console.WriteLine("Assigned task: " + assignedTask);
             break;
         case "7":
             var removedTask = taskManager.RemoveProjectTask();
             Console.WriteLine("Removed task: " + removedTask);
             break;
         case "8":
             var addedProjectId = projectManager.AddNewProject();
             Console.WriteLine("Added id: " + addedProjectId);
             break;
         case "9":
             var deletedProjectId = projectManager.CompletlyProjectRemove();
             Console.WriteLine("Deleted id: " + deletedProjectId);
             break;
         case "10":
             var getProjectById = projectManager.GetProjectById();
             Console.WriteLine("getProjectById id: " + getProjectById);
             break;
         case "11":
             var updatedProjectId = projectManager.UpdateProject();
             Console.WriteLine("Updated id: " + updatedProjectId);
             break;
         case "12":
             projectManager.ShowAllProjects();
             break;
         case "13":
             projectManager.GetProjectTasks();
             break;
         case "14":
             var projectIdByTask = projectManager.GetProjectByTask();
             Console.WriteLine("Project id by task: " + projectIdByTask);
             break;
         default:
             Console.WriteLine("Wrong action");
             break;
 
     }
}