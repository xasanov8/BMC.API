using BMC.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Domain.Entities.DTOs
{
    public class WorkerDTO
    {
        public Guid RestoranId { get; set; }
        public double Salary { get; set; }
        public List<ClientModel> Clients { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
