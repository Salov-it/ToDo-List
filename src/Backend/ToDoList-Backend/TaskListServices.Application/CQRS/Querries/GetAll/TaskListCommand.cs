using DatabasePostgres.Persistance.Dto.TaskListDto;
using MediatR;


namespace TaskListServices.Application.CQRS.Command.GetAll
{
    public class TaskListCommand : IRequest<List<GetAllTaskListDto>>
    {
    }
}
