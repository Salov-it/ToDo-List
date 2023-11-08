

namespace DatabasePostgres.Persistance.SqlRequest.TaskListSqlRequest
{
    public class TaskListSqlRequest
    {
        public string CreateTasksTable = "CREATE TABLE Tasks (id SERIAL PRIMARY KEY,texts TEXT,StatusTasks BOOLEAN, Created DATE);";

        public string Add = $"INSERT INTO tasks (texts,StatusTasks,Created)" +
            "VALUES ($1), ($2), ($3)";

        public string GetTasksInfo = "SELECT id,texts,StatusTasks,Created FROM Tasks;";

        public string Delete = "DELETE FROM Tasks WHERE id = @id;";

        public string Update = "UPDATE Tasks SET text = @text,StatusTasks = @StatusTasks WHERE id = @id RETURNING *;";
    }
}
