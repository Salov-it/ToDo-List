using Microsoft.AspNetCore.Mvc;
using TaskList_Frontend.Services.TaskListApi.Interface;
using TaskList_Frontend.Services.TaskListApi.Models.TaskList;

namespace TaskList_Frontend.Controllers
{
    public class TaskListController : Controller
    {
        private readonly ITaskListControllers _taskListControllers;
        List<TaskViewModel> _tasks = new List<TaskViewModel>();

        public TaskListController(ITaskListControllers taskListControllers)
        {
            _taskListControllers = taskListControllers;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var Content = _taskListControllers.GetAllTaskList();
           
            _tasks.Add(Content.Result);
            return View(_tasks);
        }

        [HttpPost]
        public ActionResult CreateTaskList(TaskViewModel taskViewModel)
        {
            return View();
        }

       
    }
}
