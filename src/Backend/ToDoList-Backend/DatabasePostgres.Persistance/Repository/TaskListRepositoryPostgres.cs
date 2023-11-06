using DatabasePostgres.Persistance.Dto;
using DatabasePostgres.Persistance.Dto.TaskListDto;
using DatabasePostgres.Persistance.Interface;
using DatabasePostgres.Persistance.SqlRequest.TaskListSqlRequest;
using Npgsql;

namespace DatabasePostgres.Persistance.Repository
{
    public class TaskListRepositoryPostgre : UserRepositoryPostgres, ITaskListRepositoryPostgres
    {
        TaskListSqlRequest _TaskSql = new TaskListSqlRequest();
        public async Task<string> Add(PostTaskListDto taskListDto)
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_TaskSql.Add))
            {
                cmd.Parameters.AddWithValue("(@Text",taskListDto.text);
                cmd.Parameters.AddWithValue("@StatusTasks",taskListDto.StatusTasks);
                cmd.Parameters.AddWithValue("@Created",taskListDto.Created);
                await cmd.ExecuteNonQueryAsync();
            }
            return "Выполнено";
        }

        public async Task<string> CreateTable()
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_TaskSql.CreateTasksTable))
            {
                await cmd.ExecuteNonQueryAsync();
            }
            return "Таблица Tasks создана успешно";
        }

        public async Task<string> Delete(DeleteTaskListDto deleteTaskListDto)
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_TaskSql.Delete))
            {
                cmd.Parameters.AddWithValue("(@id",deleteTaskListDto.id);
                await cmd.ExecuteNonQueryAsync();
            }
            return "Выполнено";
        }

        public GetAllTaskListDto TaskListDto = new GetAllTaskListDto();
        public List<GetAllTaskListDto> Result = new List<GetAllTaskListDto>();
        public async Task<List<GetAllTaskListDto>> GetAll()
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_TaskSql.GetTasksInfo))
            {
                await using (var reader = await cmd.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        var id = reader.GetInt16(0);
                        var text = reader.GetString(1);
                        var StatusTasks = reader.GetBoolean(2);
                        var Created = reader.GetData(3);

                        TaskListDto = new GetAllTaskListDto
                        {
                            id = id,
                            text = text,
                            StatusTasks = StatusTasks,
                            Created = Created.ToString()
                        };
                        Result.Add(TaskListDto);
                    }
                }
            }
            return Result;
        }

        public UpdateTaskListDto updateTaskListDto = new UpdateTaskListDto();
        public async Task<UpdateTaskListDto> Update(UpdateTaskListDto updateTaskListDto)
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_TaskSql.Update))
            {
                cmd.Parameters.AddWithValue("(@id",updateTaskListDto.id);
                cmd.Parameters.AddWithValue("@text",updateTaskListDto.text);
                cmd.Parameters.AddWithValue("@StatusTasks",updateTaskListDto.StatusTasks);
                await cmd.ExecuteNonQueryAsync();

                await using (var reader = await cmd.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        var id = reader.GetInt16(0);
                        var text = reader.GetString(1);
                        var StatusTasks = reader.GetBoolean(2);
                        
                        updateTaskListDto = new UpdateTaskListDto
                        {
                            id = id,
                            text = text,
                            StatusTasks = StatusTasks
                        };
                    }
                }
            }
            return updateTaskListDto;
        }
    }
}
