using BMC.Application.Abstraction;
using BMC.Application.UseCases.MenuCases.Queries;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.MenuCases.Handlers.QueryHandlers
{
    public class GetByIdMenuQueryHandler : IRequestHandler<GetByIdMenuQuery, Menu>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        public GetByIdMenuQueryHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Menu> Handle(GetByIdMenuQuery request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == request.Id);

            return menu;
        }
    }
}
