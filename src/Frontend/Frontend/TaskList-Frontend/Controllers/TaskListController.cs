﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            var Content = await _taskListControllers.TaskListAdd(taskListAdd);

            TaskListStatusModel taskListStatus = new TaskListStatusModel { Status = Content.Status };

            if(taskListStatus.Status == "Выполнено")
            {
                return RedirectToAction("Status", "TaskList");
            }
            else { return RedirectToAction("StatusEror", "TaskList"); }
        }

        [HttpGet]
        public async Task<ActionResult> ChangeTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangeTask(ChangeTaskListModel changeTaskListModel)
        {
            ChangeTaskListModel changeTaskList = new ChangeTaskListModel
            {
                id = changeTaskListModel.id,
                text = changeTaskListModel.text,
                StatusTasks = true,
                Eror = "null"
            };
            var Content = await _taskListControllers.ChangeTask(changeTaskList);
           
            if(Content == "200")
            {
                return RedirectToAction("Status", "TaskList");
            }
            else { return RedirectToAction("StatusEror", "TaskList"); };  
        }

        [HttpGet]
        public async Task<ActionResult> Status() 
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> StatusEror()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Delet()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Delet(TaskListDeleteModel taskListDelete)
        {
            var Content = await _taskListControllers.Delete(taskListDelete);

            if (Content == "OK")
            {
                return RedirectToAction("Status", "TaskList");
            }
            else { return RedirectToAction("StatusEror", "TaskList"); };
        }



    }
}
