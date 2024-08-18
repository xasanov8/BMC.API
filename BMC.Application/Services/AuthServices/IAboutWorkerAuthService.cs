using BMC.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application.Services.AuthServices
{
    public interface IAboutWorkerAuthService
    {
        public Task<string> GenerateToken(RequestLogin aboutWorker);
    }
}
