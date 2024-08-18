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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BMC.Application.UseCases.AboutWorkerCases.Handlers.CommandHandlers
{
    public class UpdateAboutWorkerCommandHandler : IRequestHandler<UpdateAboutWorkerCommand, AboutWorker>
    {
        private readonly IBMCProjDbContext _context;
        private readonly IMediator _mediator;
        private readonly IPasswordHashing _passwordHashing;

        public UpdateAboutWorkerCommandHandler(IBMCProjDbContext context, IMediator mediator, IPasswordHashing passwordHashing)
        {
            _context = context;
            _mediator = mediator;
            _passwordHashing = passwordHashing;
        }

        public async Task<AboutWorker> Handle(UpdateAboutWorkerCommand request, CancellationToken cancellationToken)
        {
            var aboutWorker = await _context.AboutWorkers.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (aboutWorker is not null)
            {
                if (null == await _context.AboutWorkers.FirstOrDefaultAsync(x => x.Login == request.Login))
                {
                    var salt = Guid.NewGuid().ToString();
                    aboutWorker.FirstName = request.FirstName;
                    aboutWorker.LastName = request.LastName;
                    aboutWorker.Number = request.Number;
                    aboutWorker.Position = request.Position;
                    aboutWorker.Login = request.Login;
                    aboutWorker.Password = _passwordHashing.Encrypt(request.Password, salt);
                    aboutWorker.Salt = salt;
                    aboutWorker.StartTime = request.StartTime;
                    aboutWorker.EndTime = request.EndTime;
                    aboutWorker.RestoranId = request.RestoranId;

                    await _context.SaveChangesAsync(cancellationToken);

                    return aboutWorker;
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
