using Microsoft.AspNetCore.Mvc;
using TaskList_Frontend.Services.TaskListApi.Interface;
using TaskList_Frontend.Services.TaskListApi.Models.Account;

namespace TaskList_Frontend.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserControllers _userControllers;

        public AccountController(IUserControllers userControllers)
        {
            _userControllers = userControllers;
        }

        [HttpGet]
        public ActionResult AccountRegistration()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult AccountRegistration(UserRegistrationModel userRegistrationModel)
        {
          _userControllers.AccountRegistration(userRegistrationModel);
          return RedirectToAction("Index","Home");
        }
    }
}
