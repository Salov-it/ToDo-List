using DatabasePostgres.Persistance.Dto.TaskListDto;
using DatabasePostgres.Persistance.Interface;
using System.Net.Http;
using System.Security.Claims;
using TaskListServices.Application.Interface;

namespace TaskListServices.Application.CQRS.Command.GetAll
{
    public class GetTaskList : IGetTaskList
    {
        private readonly ITaskListRepositoryPostgres _taskListRepositoryPostgres;
        public List<GetAllTaskListDto> Result = new List<GetAllTaskListDto>();
        public GetTaskList(ITaskListRepositoryPostgres taskListRepositoryPostgres)
        {
            _taskListRepositoryPostgres = taskListRepositoryPostgres;
        }

        public async Task<List<GetAllTaskListDto>> GetAll()
        {
            var Content = await _taskListRepositoryPostgres.GetAll();
            if(Content.Count > 0) 
            {
                return Content;
            }
            else
            {
                GetAllTaskListDto content = new GetAllTaskListDto() { Eror = "Список задач пуст" };
                Result.Add(content);
                return Result;
            }
        }
    }
}
