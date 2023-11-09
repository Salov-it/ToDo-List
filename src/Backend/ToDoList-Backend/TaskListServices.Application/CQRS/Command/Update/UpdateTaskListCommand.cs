using DatabasePostgres.Persistance.Dto.TaskListDto;
using MediatR;

namespace TaskListServices.Application.CQRS.Command.Update
{
    public class UpdateTaskListCommand : IRequest<UpdateTaskListDto>
    {
        public UpdateTaskListDto UpdateTaskListDto { get; set; }
    }
}
