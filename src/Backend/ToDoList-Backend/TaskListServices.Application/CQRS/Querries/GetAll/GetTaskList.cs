using DatabasePostgres.Persistance.Dto.TaskListDto;
using DatabasePostgres.Persistance.Interface;
using TaskListServices.Application.Interface;

namespace TaskListServices.Application.CQRS.Command.GetAll
{
    public class GetTaskList : IGetTaskList
    {
        private readonly ITaskListRepositoryPostgres _taskListRepositoryPostgres;
        public GetTaskList(ITaskListRepositoryPostgres taskListRepositoryPostgres)
        {
            _taskListRepositoryPostgres = taskListRepositoryPostgres;
        }

        public async Task<List<GetAllTaskListDto>> GetAll()
        {
          return await _taskListRepositoryPostgres.GetAll();
        }
    }
}
