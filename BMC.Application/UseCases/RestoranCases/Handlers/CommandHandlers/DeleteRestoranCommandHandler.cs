using BMC.Application.Abstraction;
using BMC.Application.UseCases.RestoranCases.Commands;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.RestoranCases.Handlers.CommandHandlers
{
    public class DeleteRestoranCommandHandler : IRequestHandler<DeleteRestoranCommand, ResponseModel>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;

        public DeleteRestoranCommandHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteRestoranCommand request, CancellationToken cancellationToken)
        {
            var restoran = await _context.Restorans.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (restoran != null)
            {
                _context.Restorans.Remove(restoran);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Id} => User Deleted",
                    isSucces = true
                };
            }

            return new ResponseModel
            {
                Message = "User is maybe null",
                StatusCode = 400
            };
        }
    }
}
