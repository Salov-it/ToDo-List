using Microsoft.AspNetCore.Mvc;
using TaskList_Frontend.Services.TaskListApi.Interface;

namespace TaskList_Frontend.Controllers
{
    public class TaskListController : Controller
    {
        private readonly ITaskListControllers _taskListControllers;

        public TaskListController(ITaskListControllers taskListControllers)
        {
            _taskListControllers = taskListControllers;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var Content = _taskListControllers.GetAllTaskList();
            return View(Content);
        }

        // GET: TaskListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
