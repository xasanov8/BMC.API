using BMC.Application.Abstraction;
using BMC.Application.UseCases.RestoranCases.Queries;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.RestoranCases.Handlers.QueryHandlers
{
    public class GetAllRestoranAboutWorkersQueryHandler : IRequestHandler<GetAllRestoranAboutWorkersQuery, List<AboutWorker>>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;

        public GetAllRestoranAboutWorkersQueryHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        async Task<List<AboutWorker>> IRequestHandler<GetAllRestoranAboutWorkersQuery, List<AboutWorker>>.Handle(GetAllRestoranAboutWorkersQuery request, CancellationToken cancellationToken)
        {
            var restoranAboutWorkers = await _context.AboutWorkers
                                          .Where(x => x.RestoranId == request.RestoranId)
                                          .ToListAsync(cancellationToken);

            return restoranAboutWorkers;
        }
    }
}
