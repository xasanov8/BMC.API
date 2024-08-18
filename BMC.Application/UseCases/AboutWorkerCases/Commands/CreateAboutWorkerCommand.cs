using BMC.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.AboutWorkerCases.Commands
{
    public class CreateAboutWorkerCommand : IRequest<ResponseModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public string Position { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Guid RestoranId { get; set; }
    }
}
