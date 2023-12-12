namespace TaskList_Frontend.Services.TaskListApi.Models.TaskList
{
    public class TaskViewModel
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool StatusTasks { get; set; }
        public DateTime Created { get; set; }
        public string Eror { get; set; }

    }
}
