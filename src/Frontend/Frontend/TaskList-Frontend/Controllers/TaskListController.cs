using Microsoft.AspNetCore.Mvc;
using TaskList_Frontend.Services.TaskListApi.Interface;
using TaskList_Frontend.Services.TaskListApi.Models.TaskList;

namespace TaskList_Frontend.Controllers
{
    public class TaskListController : Controller
    {
        private readonly ITaskListControllers _taskListControllers;

        public TaskListController(ITaskListControllers taskListControllers)
        {
            _taskListControllers = taskListControllers;
        }

        
        public ActionResult Index()
        {
            //var Content = _taskListControllers.GetAllTaskList();
            DateTime localDateTime = DateTime.Now;
            TaskViewModel task = new TaskViewModel
            {
                id =1,
                text = "БОБ СУЙ",
                statusTasks = true,
                created = localDateTime
            };
            List<TaskViewModel> taskList = new List<TaskViewModel>();
            
            taskList.Add(task);
           
            return View(taskList);
        }

        [HttpPost]
        public ActionResult CreateTaskList(TaskViewModel taskViewModel)
        {
            return View();
        }

       
    }
}
