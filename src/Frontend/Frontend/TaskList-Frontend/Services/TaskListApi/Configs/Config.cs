namespace TaskList_Frontend.Services.TaskListApi.Configs
{
    public class Config
    {
        public string AccountRegistration = "https://localhost:44319/api/Account/AccountRegistration";
       
        public string Authorization = "https://localhost:44319/api/Account/Authorization";

        //TaskList
        public string GetAllTaskList = "https://localhost:44319/api/TaskListServices/GetAll";
        public string TaskListAdd = "https://localhost:44319/api/TaskListServices/Add";
        public string ChangeTask = "https://localhost:44319/api/TaskListServices/Update";
        public string Delete = "https://localhost:44319/api/TaskListServices/Delete";
    } 
}
