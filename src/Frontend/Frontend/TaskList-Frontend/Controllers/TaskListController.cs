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

        private IEnumerable<TaskViewModel> GetTasks()
        {
            DateTime localDateTime = DateTime.Now;
            bool yes = true;
            // Здесь получите свои данные задач (например, из базы данных)
            // Возвращаем простой пример для демонстрации
            return new List<TaskViewModel>
            {
             new TaskViewModel{id = 1,text = "супер бобер",statusTasks = yes,created =  localDateTime}
               // Добавьте свои задачи в коллекцию
            };
        }

        [HttpPost]
        public ActionResult CreateTaskList(TaskViewModel taskViewModel)
        {
            return View();
        }

       
    }
}
