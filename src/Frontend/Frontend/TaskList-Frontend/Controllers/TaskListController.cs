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
        public async Task<ActionResult> Index()
        {
            var Content = await _taskListControllers.GetAllTaskList();
            return View(Content);
        }

        [HttpGet]
        public ActionResult TaskListAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TaskListAdd(TaskListAddModel taskListAdd)
        {
            TaskListAddModel taskList = new TaskListAddModel
            {
                Text = taskListAdd.Text,
                StatusTasks = true
            };
            var Content = await _taskListControllers.TaskListAdd(taskList);
            TaskListStatusModel taskListStatus = new TaskListStatusModel { Status = Content.Status };
            if(taskListStatus.Status == "Выполнено")
            {
                return RedirectToAction("Status", "TaskList");
            }
            else { Console.WriteLine("Ошибка: Добавления задачи"); }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Status()
        {
            return View();
        }

        
    }
}
