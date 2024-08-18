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
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, List<Menu>>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        public GetAllMenusQueryHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        async Task<List<Menu>> IRequestHandler<GetAllMenusQuery, List<Menu>>.Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            var menus = await _context.Menus.ToListAsync();

            return menus;
        }
    }
}
