using BMC.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Domain.Entities.DTOs
{
    public class ClientModelDTO
    {
        public int TableNumber { get; set; }
        public List<Menu> Menus { get; set; }
        public DateTime OrderTime { get; set; } = DateTime.UtcNow;
    }
}
