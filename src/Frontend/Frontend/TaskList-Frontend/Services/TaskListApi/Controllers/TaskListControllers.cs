using Newtonsoft.Json;
using System.Net.Http.Headers;
using TaskList_Frontend.Services.TaskListApi.Configs;
using TaskList_Frontend.Services.TaskListApi.Interface;
using TaskList_Frontend.Services.TaskListApi.Models.TaskList;

namespace TaskList_Frontend.Services.TaskListApi.Controllers
{
    public class TaskListControllers : ITaskListControllers
    {
        HttpClient client = new HttpClient();
        HttpContext context = new DefaultHttpContext();

        Config config = new Config();
        public async Task<TaskViewModel> GetAllTaskList()
        {
            string Token = context.Request.Cookies["AccessToken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            using var Resuilt = await client.GetAsync(config.GetAllTaskList);
            var ContentJson = Resuilt.Content.ReadAsStringAsync();

            var Content = JsonConvert.DeserializeObject<TaskViewModel>(ContentJson.Result);
            return Content;
        }
    }
}
