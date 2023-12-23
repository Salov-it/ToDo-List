using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using TaskList_Frontend.Services.TaskListApi.Configs;
using TaskList_Frontend.Services.TaskListApi.Interface;
using TaskList_Frontend.Services.TaskListApi.Models.TaskList;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

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
            var ContentJson = await Resuilt.Content.ReadAsStringAsync();
            var Content =  JsonSerializer.Deserialize<List<TaskViewModel>>(ContentJson);
            return Content;
        }

        public async Task<TaskListStatusModel> TaskListAdd(TaskListAddModel taskListAdd)
        {
            string Token = _ContextAccessor.HttpContext.Request.Cookies["AccessToken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            
            DateTime DateTime = DateTime.Now;

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(Token) as JwtSecurityToken;

            var UserName = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");

            TaskListAddModel taskList = new TaskListAddModel
            {
                NickName = UserName.Value,
                text = taskListAdd.text,
                StatusTasks = true,
                Created = DateTime
            };
            var Json = JsonSerializer.Serialize<TaskListAddModel>(taskList);

            var Content = new StringContent(Json, Encoding.UTF8, "application/json");
            using var Resuilt = await client.PostAsync(config.TaskListAdd, Content);
            var ContentJson = Resuilt.Content.ReadAsStringAsync();
            TaskListStatusModel taskListStatus = new TaskListStatusModel { Status = ContentJson.Result };

            return taskListStatus;
        }

        public async Task<string> ChangeTask(ChangeTaskListModel changeTaskList)
        {
            string Token = _ContextAccessor.HttpContext.Request.Cookies["AccessToken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var JsonContent = JsonSerializer.Serialize<ChangeTaskListModel>(changeTaskList);

            var Content = new StringContent(JsonContent, Encoding.UTF8, "application/json");

            try
            {
                using var Resuilt = await client.PutAsync(config.ChangeTask, Content);
                var ResuiltStatusCode = Resuilt.StatusCode.ToString();
                return ResuiltStatusCode;
            }
            catch (HttpRequestException ex) 
            {
                // Логирование ошибки
                return "500";
            }
            catch(Exception ex)
            {
                return "500";
            }  
        }

        public async Task<string> Delete(TaskListDeleteModel taskListDeleteModel)
        {
            string Token = _ContextAccessor.HttpContext.Request.Cookies["AccessToken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var JsonContent = JsonSerializer.Serialize<TaskListDeleteModel>(taskListDeleteModel);

            var Content = new StringContent(JsonContent, Encoding.UTF8, "application/json");

            try
            {
                using var Resuilt = new HttpRequestMessage(HttpMethod.Delete, config.Delete)
                {
                    Content = Content
                };
                using var response = await client.SendAsync(Resuilt);
                return response.StatusCode.ToString();
            }
            catch (HttpRequestException ex)
            {
                // Логирование ошибки
                return "500";
            }
            catch (Exception ex)
            {
                return "500";
            }
        }
    }
}
