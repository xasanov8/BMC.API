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
    public class GetByIdAboutWorkerQueryHandler : IRequestHandler<GetByIdAboutWorkerQuery, AboutWorker>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        public GetByIdAboutWorkerQueryHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<AboutWorker> Handle(GetByIdAboutWorkerQuery request, CancellationToken cancellationToken)
        {
            var aboutworker = await _context.AboutWorkers.FirstOrDefaultAsync(x => x.Id == request.Id);

            return aboutworker;
        }
    }
}
