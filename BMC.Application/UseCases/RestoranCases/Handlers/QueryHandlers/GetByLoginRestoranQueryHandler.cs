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
    public class GetByLoginRestoranQueryHandler : IRequestHandler<GetByLoginRestoranQuery, Restoran>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        public GetByLoginRestoranQueryHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Restoran> Handle(GetByLoginRestoranQuery request, CancellationToken cancellationToken)
        {
            var restoran = await _context.Restorans.FirstOrDefaultAsync(x => x.Login == request.Login);

            return restoran;
        }
    }
}
