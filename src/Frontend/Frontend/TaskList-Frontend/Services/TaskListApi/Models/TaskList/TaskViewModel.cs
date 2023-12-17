using Newtonsoft.Json;

namespace TaskList_Frontend.Services.TaskListApi.Models.TaskList
{
    public class TaskViewModel
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool statusTasks { get; set; }
        
        public DateTime created { get; set; }
        public string eror { get; set; }

    }
}
