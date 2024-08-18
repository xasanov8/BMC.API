using BMC.Application.Abstraction;
using BMC.Application.UseCases.MenuCases.Commands;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.MenuCases.Handlers.CommandHandlers
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, ResponseModel>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;

        public DeleteMenuCommandHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Id} => -1 Menu item Deleted",
                    isSucces = true
                };
            }

            return new ResponseModel
            {
                Message = "Menu item is maybe null",
                StatusCode = 400
            };
        }
    }
}
