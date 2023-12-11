using Newtonsoft.Json;
using System.Net.Http.Headers;
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

        public TaskListControllers(IHttpContextAccessor ContextAccessor)
        {
            _ContextAccessor = ContextAccessor;
        }
        Config config = new Config();
        public async Task <TaskViewModel> GetAllTaskList()
        {
            string Token = _ContextAccessor.HttpContext.Request.Cookies["AccessToken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            using var Resuilt = await client.GetAsync(config.GetAllTaskList);
            var ContentJson = Resuilt.Content.ReadAsStringAsync();
            var Content = JsonConvert.DeserializeObject<TaskViewModel>(ContentJson.Result);
            TaskViewModel taskView = new TaskViewModel
            {
                id = Content.id,
                text = Content.text,
                statusTasks = Content.statusTasks,
                created = Content.created,
                eror = Content.eror
            };
            return taskView;
        }
    }
}
