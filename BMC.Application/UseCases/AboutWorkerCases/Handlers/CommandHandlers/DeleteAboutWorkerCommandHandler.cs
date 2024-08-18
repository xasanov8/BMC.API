using BMC.Application.Abstraction;
using BMC.Application.UseCases.AboutWorkerCases.Commands;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.AboutWorkerCases.Handlers.CommandHandlers
{
    public class DeleteAboutWorkerCommandHandler : IRequestHandler<DeleteAboutWorkerCommand, ResponseModel>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;

        public DeleteAboutWorkerCommandHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteAboutWorkerCommand request, CancellationToken cancellationToken)
        {
            var aboutWorker = await _context.AboutWorkers.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (aboutWorker != null)
            {
                _context.AboutWorkers.Remove(aboutWorker);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Id} => AboutWorker Deleted",
                    isSucces = true
                };
            }

            return new ResponseModel
            {
                Message = "AboutWorker is maybe null",
                StatusCode = 400
            };
        }
    }
}
