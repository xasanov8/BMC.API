using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Domain.Entities.Models
{
    public class Menu
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        public Guid RestoranId { get; set; }

    }
}
