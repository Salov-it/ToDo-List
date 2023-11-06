using DatabasePostgres.Persistance.Dto.TaskListDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskListServices.Application.CQRS.Command.Create;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListServicesController : ControllerBase
    {
        private readonly IMediator mediator;
        public TaskListServicesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostTaskListDto taskListDto)
        {
            var Content = new CreateTaskListCommand
            {
                CreateTaskListDto = taskListDto,
            };
            var answer = await mediator.Send(Content);
            return Ok(answer);
        }
    }
}
