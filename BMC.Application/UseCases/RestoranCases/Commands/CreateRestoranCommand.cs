using BMC.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.RestoranCases.Commands
{
    public class CreateRestoranCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
