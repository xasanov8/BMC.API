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
    public class CreateRestoranCommandHandler : IRequestHandler<CreateRestoranCommand, ResponseModel>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        private readonly IPasswordHashing _passwordHashing;

        public CreateRestoranCommandHandler(IBMCProjDbContext context, IMediator mediator, IPasswordHashing passwordHashing)
        {
            _context = context;
            _mediator = mediator;
            _passwordHashing = passwordHashing;
        }

        public async Task<ResponseModel> Handle(CreateRestoranCommand request, CancellationToken cancellationToken)
        {
            if (request != null && null == await _context.Restorans.FirstOrDefaultAsync(x => x.Login == request.Login))
            {
                var salt = Guid.NewGuid().ToString();
                var restoran = new Restoran
                {
                    Name = request.Name,
                    Number = request.Number,
                    Login = request.Login,
                    Password = _passwordHashing.Encrypt(request.Password, salt),
                    Salt = salt
                };

                await _context.Restorans.AddAsync(restoran, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Login} => Restoran Created",
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
