using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TaskList_Frontend.Services.TaskListApi.Configs;
using TaskList_Frontend.Services.TaskListApi.Interface;
using TaskList_Frontend.Services.TaskListApi.Models.TaskList;

namespace TaskList_Frontend.Services.TaskListApi.Controllers
{
    public class TaskListControllers : ITaskListControllers
    {
        private readonly IHttpContextAccessor _ContextAccessor;
        HttpClient client = new HttpClient();
        HttpContext context = new DefaultHttpContext();
        List<TaskViewModel> content = new List<TaskViewModel>();
        Config config = new Config();

        public TaskListControllers(IHttpContextAccessor ContextAccessor)
        {
            _ContextAccessor = ContextAccessor;
        }
       
        public async Task<List<TaskViewModel>> GetAllTaskList()
        {
            string Token = _ContextAccessor.HttpContext.Request.Cookies["AccessToken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            using var Resuilt = await client.GetAsync(config.GetAllTaskList);
            var ContentJson = Resuilt.Content.ReadAsStringAsync();
            var Content = JsonSerializer.Deserialize<List<TaskViewModel>>(ContentJson.Result);
            return Content;
        }

        public async Task<TaskListAddModel> TaskListAdd(TaskListAddModel taskListAdd)
        {
            string Token = _ContextAccessor.HttpContext.Request.Cookies["AccessToken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var Json = JsonSerializer.Serialize<TaskListAddModel>(taskListAdd);

            var Content = new StringContent(Json, Encoding.UTF8, "application/json");
            using var Resuilt = await client.PostAsync(config.TaskListAdd,Content);
            var ContentJson = Resuilt.Content.ReadAsStringAsync();
            return  taskListAdd;
        }

    }
}
