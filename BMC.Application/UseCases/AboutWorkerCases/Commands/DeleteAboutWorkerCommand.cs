using BMC.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.AboutWorkerCases.Commands
{
    public class DeleteAboutWorkerCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
