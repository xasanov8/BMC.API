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
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, Menu>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;

        public UpdateMenuCommandHandler(IBMCProjDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Menu> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (menu is not null)
            {
                if (null == await _context.Menus.FirstOrDefaultAsync(x => x.Name == request.Name))
                {
                    var salt = Guid.NewGuid().ToString();
                    menu.Name = request.Name;
                    menu.Price = request.Price;
                    menu.Available = request.Available;
                    menu.RestoranId = request.RestoranId;

                    await _context.SaveChangesAsync(cancellationToken);

                    return menu;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }
    }
}
