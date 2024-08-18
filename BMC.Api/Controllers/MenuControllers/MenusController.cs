using BMC.Application.Abstraction;
using BMC.Application.UseCases.AboutWorkerCases.Commands;
using BMC.Application.UseCases.AboutWorkerCases.Queries;
using BMC.Application.UseCases.MenuCases.Commands;
using BMC.Application.UseCases.MenuCases.Queries;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMC.Api.Controllers.MenuControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;

        public MenusController(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Menu>>> GetAllMenus()
        {
            var result = await _mediator.Send(new GetAllMenusQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Menu>> GetByIdMenu(GetByIdMenuQuery command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Menu>> UpdateMenu(UpdateMenuCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenu(DeleteMenuCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
