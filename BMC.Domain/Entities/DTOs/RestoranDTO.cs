using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BMC.Domain.Entities.DTOs
{
    public class RestoranDTO
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public string Salt { get; set; }
    }
}
