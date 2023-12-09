namespace TaskList_Frontend.Services.TaskListApi.Controllers
{
    public class UserControllers
    {
        private readonly HttpClient _httpClient;

        public UserControllers(HttpClient client)
        {
            _httpClient = client;
        }

        public void AccountRegistration(string Login, string Password)
        {

        }
    }
}
