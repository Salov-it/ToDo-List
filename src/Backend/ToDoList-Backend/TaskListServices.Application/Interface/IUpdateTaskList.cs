using DatabasePostgres.Persistance.Dto.TaskListDto;

namespace TaskListServices.Application.Interface
{
    public interface IUpdateTaskList
    {
        Task<UpdateTaskListDto> Update(UpdateTaskListDto updateTaskListDto);
    }
}
