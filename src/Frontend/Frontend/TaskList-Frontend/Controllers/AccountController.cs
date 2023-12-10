using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;
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

        [HttpGet]
        public ActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult AccountRegistration(UserRegistrationModel userRegistrationModel)
        {
          _userControllers.AccountRegistration(userRegistrationModel);
          return RedirectToAction("Authorization", "Account");
        }

        [HttpPost]
        public  ActionResult Authorization(UserAuthorizationModel userAuthorization)
        {
            var TokenJson = _userControllers.Authorization(userAuthorization);
            var Token = JsonConvert.DeserializeObject<JwtTokenJson>(TokenJson.Result);

            CookieOptions cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1), // Установите срок действия по вашему усмотрению
                HttpOnly = true,
                Secure = true, // Рекомендуется использовать только по HTTPS
                SameSite = SameSiteMode.Strict,
            };
            Response.Cookies.Append("AccessToken", Token.JwtToken,cookieOptions);
            return RedirectToAction("Index", "Home");
        }  
    }
}
