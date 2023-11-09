using DatabasePostgres.Persistance.Dto.TaskListDto;
using MediatR;

namespace TaskListServices.Application.CQRS.Command.Delete
{
    public class DeleteTaskListDtoCommand : IRequest<string>
    {
        public DeleteTaskListDto deleteTaskListDto { get; set; }
    }
}
