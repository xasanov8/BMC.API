using BMC.Domain.Entities.DTOs;
using BMC.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.AboutWorkerCases.Commands
{
    public class UpdateAboutWorkerCommand : AboutWorkerDTO, IRequest<AboutWorker>
    {
        public Guid Id { get; set; }
    }
}
