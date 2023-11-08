using DatabasePostgres.Persistance.Dto.TaskListDto;



namespace TaskListServices.Application.Interface
{
    public interface IGetTaskList
    {
        Task<List<GetAllTaskListDto>> GetAll();
    }
}
