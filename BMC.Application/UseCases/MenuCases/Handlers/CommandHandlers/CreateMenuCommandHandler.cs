using BMC.Application.Abstraction;
using BMC.Application.Services.PasswordHash;
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
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ResponseModel>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;

        public CreateMenuCommandHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            if (request != null && null == await _context.Menus.FirstOrDefaultAsync(x => x.Name == request.Name))
            {
                var menu = new Menu
                {
                    Name = request.Name,
                    Price = request.Price,
                    Available = request.Available,
                    RestoranId = request.RestoranId
                };

                await _context.Menus.AddAsync(menu, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Name} => +1 Menu item Created",
                    isSucces = true
                };
            }

            return new ResponseModel
            {
                Message = "Catalog is maybe null",
                StatusCode = 400
            };
        }
    }
}
