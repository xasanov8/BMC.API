using BMC.Application.Abstraction;
using BMC.Application.UseCases.AboutWorkerCases.Commands;
using BMC.Application.UseCases.AboutWorkerCases.Queries;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMC.Api.Controllers.AboutWorkerControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutWorkersController : ControllerBase
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;

        public AboutWorkersController(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AboutWorker>>> GetAllAboutWorkers()
        {
            var result = await _mediator.Send(new GetAllAboutWorkersQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AboutWorker>> GetByIdAboutWorker(GetByIdAboutWorkerQuery command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutWorker(CreateAboutWorkerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<AboutWorker>> UpdateAboutWorker(UpdateAboutWorkerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAboutWorker(DeleteAboutWorkerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
