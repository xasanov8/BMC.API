using BMC.Application.Abstraction;
using BMC.Application.UseCases.MenuCases.Commands;
using BMC.Application.UseCases.MenuCases.Queries;
using BMC.Application.UseCases.RestoranCases.Commands;
using BMC.Application.UseCases.RestoranCases.Queries;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMC.Api.Controllers.RestoranControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestoransController : ControllerBase
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;

        public RestoransController(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Restoran>>> GetAllRestorans()
        {
            var result = await _mediator.Send(new GetAllRestoransQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Menu>>> GetAllRestoranMenus(GetAllRestoranMenusQuery command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<AboutWorker>>> GetAllRestoranAboutWorkers(GetAllRestoranAboutWorkersQuery command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Menu>> GetByIdRestoran(GetByIdRestoranQuery command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestoran(CreateRestoranCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Restoran>> UpdateRestoran(UpdateRestoranCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRestoran(DeleteRestoranCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
