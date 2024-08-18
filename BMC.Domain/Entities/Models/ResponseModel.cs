using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Domain.Entities.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool isSucces { get; set; } = false;
    }
}
