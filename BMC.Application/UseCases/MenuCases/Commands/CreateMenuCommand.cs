using BMC.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.UseCases.MenuCases.Commands
{
    public class CreateMenuCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        public Guid RestoranId { get; set; }
    }
}
