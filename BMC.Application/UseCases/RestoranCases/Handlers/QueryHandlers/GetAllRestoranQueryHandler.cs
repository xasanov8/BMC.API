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
    public class GetAllRestoranQueryHandler : IRequestHandler<GetAllRestoransQuery, List<Restoran>>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        public GetAllRestoranQueryHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        async Task<List<Restoran>> IRequestHandler<GetAllRestoransQuery, List<Restoran>>.Handle(GetAllRestoransQuery request, CancellationToken cancellationToken)
        {
            var restorans = await _context.Restorans.ToListAsync();

            return restorans;
        }
    }
}
