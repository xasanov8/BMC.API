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
    public class GetByIdRestoranQueryHandler : IRequestHandler<GetByIdRestoranQuery, Restoran>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        public GetByIdRestoranQueryHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Restoran> Handle(GetByIdRestoranQuery request, CancellationToken cancellationToken)
        {
            var restoran = await _context.Restorans.FirstOrDefaultAsync(x => x.Id == request.Id);

            return restoran;
        }
    }
}
