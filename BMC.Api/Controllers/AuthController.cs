using BMC.Application.Services.AuthServices;
using BMC.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMC.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAboutWorkerAuthService _aboutWorkerAuthService;
        private readonly IRestoranAuthService _restoranAuthService;

        public AuthController(IAboutWorkerAuthService aboutWorkerAuthService, IRestoranAuthService restoranAuthService)
        {
            _aboutWorkerAuthService = aboutWorkerAuthService;
            _restoranAuthService = restoranAuthService;
        }

        [HttpPost]
        public async Task<string> LoginRestoran(RequestLogin restoran)
        {
            return await _restoranAuthService.GenerateToken(restoran);
        }

        [HttpPost]
        public async Task<string> LoginAboutWorker(RequestLogin aboutWorker)
        {
            return await _aboutWorkerAuthService.GenerateToken(aboutWorker);
        }

    }
}
