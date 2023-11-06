

namespace DatabasePostgres.Persistance.SqlRequest.TaskListSqlRequest
{
    public class TaskListSqlRequest
    {
        public string CreateTasksTable = "CREATE TABLE Tasks (id SERIAL PRIMARY KEY,text TEXT ,StatusTasks BOOLEAN, Created DATE);";

        public string Add = $"INSERT INTO Tasks (text,StatusTasks,Created)" +
            "VALUES (@Text,@StatusTasks,@Created)";

        public string GetTasksInfo = "SELECT id,text,StatusTasks,Created FROM Tasks;";

        public string Delete = "DELETE FROM Tasks WHERE id = @id;";

        public string Update = "UPDATE Tasks SET text = @text,StatusTasks = @StatusTasks WHERE id = @id RETURNING *;";
    }
}
