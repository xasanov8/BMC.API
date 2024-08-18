using BMC.Application.Abstraction;
using BMC.Application.Services.PasswordHash;
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
    public class CreateAboutWorkerCommandHandler : IRequestHandler<CreateAboutWorkerCommand, ResponseModel>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        private readonly IPasswordHashing _passwordHashing;

        public CreateAboutWorkerCommandHandler(IBMCProjDbContext context, IMediator mediator, IPasswordHashing passwordHashing)
        {
            _context = context;
            _mediator = mediator;
            _passwordHashing = passwordHashing;
        }

        public async Task<ResponseModel> Handle(CreateAboutWorkerCommand request, CancellationToken cancellationToken)
        {
            if (request != null && null == await _context.AboutWorkers.FirstOrDefaultAsync(x => x.Login == request.Login))
            {
                var salt = Guid.NewGuid().ToString();
                var aboutworker = new AboutWorker
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Number = request.Number,
                    Position = request.Position,
                    Login = request.Login,
                    Password = _passwordHashing.Encrypt(request.Password, salt),
                    Salt = salt,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    RestoranId = request.RestoranId,
                    
                };

                await _context.AboutWorkers.AddAsync(aboutworker, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Login} => AboutWorker Created",
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
