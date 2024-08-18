using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Domain.Entities.DTOs
{
    public class MenuDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        public Guid RestoranId { get; set; }
    }
}
