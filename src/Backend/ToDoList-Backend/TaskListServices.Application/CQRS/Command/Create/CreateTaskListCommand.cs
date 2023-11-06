using DatabasePostgres.Persistance.Dto.TaskListDto;
using MediatR;

namespace TaskListServices.Application.CQRS.Command.Create
{
    public class CreateTaskListCommand : IRequest<string>
    {
        public PostTaskListDto CreateTaskListDto { get; set; }
    }
}
