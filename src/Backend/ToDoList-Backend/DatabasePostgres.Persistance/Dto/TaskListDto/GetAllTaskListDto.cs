﻿

namespace DatabasePostgres.Persistance.Dto.TaskListDto
{
    public class GetAllTaskListDto
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool StatusTasks { get; set; }
        public DateTime Created { get; set; }
       
    }
}
