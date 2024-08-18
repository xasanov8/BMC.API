using BMC.Application.Abstraction;
using BMC.Application.UseCases.AboutWorkerCases.Queries;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.AboutWorkerCases.Handlers.QueryHandlers
{
    public class GetAllAboutWorkersQueryHandler : IRequestHandler<GetAllAboutWorkersQuery, List<AboutWorker>>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        public GetAllAboutWorkersQueryHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        async Task<List<AboutWorker>> IRequestHandler<GetAllAboutWorkersQuery, List<AboutWorker>>.Handle(GetAllAboutWorkersQuery request, CancellationToken cancellationToken)
        {
            var aboutworkers = await _context.AboutWorkers.ToListAsync();

            return aboutworkers;
        }
    }
}
