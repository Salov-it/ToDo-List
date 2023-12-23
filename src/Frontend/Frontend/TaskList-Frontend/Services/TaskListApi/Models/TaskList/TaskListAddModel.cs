namespace TaskList_Frontend.Services.TaskListApi.Models.TaskList
{
    public class TaskListAddModel
    {
        public string NickName { get; set; }
        public string text { get; set; }
        public bool StatusTasks { get; set; }
        public DateTime Created { get; set; }
    }
}
