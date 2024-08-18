using BMC.Application.Abstraction;
using BMC.Application.UseCases.RestoranCases.Queries;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BMC.Application.UseCases.RestoranCases.Handlers.QueryHandlers
{
    public class GetAllRestoranMenusQueryHandler : IRequestHandler<GetAllRestoranMenusQuery, List<Menu>>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;

        public GetAllRestoranMenusQueryHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        async Task<List<Menu>> IRequestHandler<GetAllRestoranMenusQuery, List<Menu>>.Handle(GetAllRestoranMenusQuery request, CancellationToken cancellationToken)
        {
            var restoranMenus = await _context.Menus
                                          .Where(x => x.RestoranId == request.RestoranId)
                                          .ToListAsync(cancellationToken);

            return restoranMenus;
        }
    }
}
