using System.Text.Json;
using TaskList_Frontend.Services.TaskListApi.Configs;
using TaskList_Frontend.Services.TaskListApi.Models.Account;

namespace TaskList_Frontend.Services.TaskListApi.Controllers
{
    public class UserControllers
    {
        private readonly HttpClient _httpClient;

        Config config = new Config();

        public UserControllers(HttpClient client)
        {
            _httpClient = client;
            
        }

        public async void AccountRegistration(UserRegistrationModel userRegistrationModel)
        {
            UserRegistrationModel UserContent = new UserRegistrationModel
            {
                login = userRegistrationModel.login,
                password = userRegistrationModel.password,
                email = userRegistrationModel.email,
            };
            string Content = JsonSerializer.Serialize(UserContent);
            using var Resuilt = await _httpClient.PostAsJsonAsync(config.AccountRegistration,Content);
        }

        public async void Authorization(UserAuthorizationModel userAuthorization)
        {
            UserAuthorizationModel UserContent = new UserAuthorizationModel
            {
                Login = userAuthorization.Login,
                Password = userAuthorization.Password,
            };
            string Content = JsonSerializer.Serialize(UserContent);
            using var Resuilt = await _httpClient.PostAsJsonAsync(config.Authorization, Content);
        }
    }
}
