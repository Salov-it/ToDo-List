using DatabasePostgres.Persistance.Dto.TaskListDto;

namespace TaskListServices.Application.Interface
{
    public interface IDeletTaskList
    {
        Task<string> Delete(DeleteTaskListDto deleteTaskListDto);
    }
}
