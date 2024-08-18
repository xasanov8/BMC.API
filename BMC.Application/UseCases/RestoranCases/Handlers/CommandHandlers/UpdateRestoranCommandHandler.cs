using BMC.Application.Abstraction;
using BMC.Application.Services.PasswordHash;
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
    public class UpdateRestoranCommandHandler : IRequestHandler<UpdateRestoranCommand, Restoran>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        private readonly IPasswordHashing _passwordHashing;

        public UpdateRestoranCommandHandler(IBMCProjDbContext context, IMediator mediator, IPasswordHashing passwordHashing)
        {
            _context = context;
            _mediator = mediator;
            _passwordHashing = passwordHashing;
        }

        public async Task<Restoran> Handle(UpdateRestoranCommand request, CancellationToken cancellationToken)
        {
            var restoran = await _context.Restorans.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (restoran is not null)
            {
                if (null == await _context.Restorans.FirstOrDefaultAsync(x => x.Login == request.Login))
                {
                    var salt = Guid.NewGuid().ToString();
                    restoran.Name = request.Name;
                    restoran.Number = request.Number;
                    restoran.Login = request.Login;
                    restoran.Password = _passwordHashing.Encrypt(request.Password, salt);
                    restoran.Salt = salt;

                    await _context.SaveChangesAsync(cancellationToken);

                    return restoran;
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
