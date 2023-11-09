using DatabasePostgres.Persistance.Dto.TaskListDto;

namespace TaskListServices.Application.Interface
{
    public interface ICreateTaskList
    {
        Task<string> Create(PostTaskListDto taskListDto);
    }
}
