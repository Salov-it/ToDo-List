using System.Text;
using System.Text.Json;
using TaskList_Frontend.Services.TaskListApi.Configs;
using TaskList_Frontend.Services.TaskListApi.Interface;
using TaskList_Frontend.Services.TaskListApi.Models.Account;

namespace TaskList_Frontend.Services.TaskListApi.Controllers
{
    public class UserControllers : IUserControllers
    {
        
        HttpClient client = new HttpClient();

        Config config = new Config();

        public async void AccountRegistration(UserRegistrationModel userRegistrationModel)
        {
            UserRegistrationModel UserContent = new UserRegistrationModel
            {
                login = userRegistrationModel.login,
                password = userRegistrationModel.password,
                email = userRegistrationModel.email,
            };
            string Content = JsonSerializer.Serialize(UserContent);
            var content = new StringContent(Content, Encoding.UTF8, "application/json");
            using var Resuilt = await client.PostAsync(config.AccountRegistration,content);
        }

        public async void Authorization(UserAuthorizationModel userAuthorization)
        {
            UserAuthorizationModel UserContent = new UserAuthorizationModel
            {
                Login = userAuthorization.Login,
                Password = userAuthorization.Password,
            };
            string Content = JsonSerializer.Serialize(UserContent);
            var content = new StringContent(Content, Encoding.UTF8, "application/json");
            using var Resuilt = await client.PostAsync(config.Authorization,content);
        }
    }
}
