using BMC.Application.Services.PasswordHash;
using BMC.Application.UseCases.AboutWorkerCases.Queries;
using BMC.Application.UseCases.RestoranCases.Queries;
using BMC.Domain.Entities.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BMC.Application.Services.AuthServices
{
    public class RestoranAuthService : IRestoranAuthService
    {
        private readonly IConfiguration _conf;
        private readonly IMediator _mediatR;
        private readonly IPasswordHashing _passwordHashing;

        public RestoranAuthService(IConfiguration conf, IMediator mediatR, IPasswordHashing passwordHashing)
        {
            _conf = conf;
            _mediatR = mediatR;
            _passwordHashing = passwordHashing;
        }

        public async Task<string> GenerateToken(RequestLogin restoran)
        {
            if (restoran == null)
            {
                return "Restoran Not Found";
            }

            if (await UserExist(restoran))
            {
                var query = new GetByLoginRestoranQuery() { Login = restoran.Login };

                var result = await _mediatR.Send(query);

                List<Claim> claims = new List<Claim>()
                {
                    new Claim("Login", restoran.Login),
                    new Claim("Id", result.Id.ToString()),
                    new Claim("CreatedDate", DateTime.UtcNow.ToString())
                };

                return await GenerateTokenn(claims);
            }

            return "Un Authorize";
        }

        public async Task<string> GenerateTokenn(IEnumerable<Claim> additionalClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_conf["JWT:ExpireDate"] ?? "1");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _conf["JWT:ValidIssuer"],
                audience: _conf["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(exDate),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        public async Task<bool> UserExist(RequestLogin restoran)
        {
            var query = new GetByLoginRestoranQuery() { Login = restoran.Login };

            var result = await _mediatR.Send(query);

            if (result == null) return false;

            if (restoran.Login == result.Login && _passwordHashing.Verify(result.Password, restoran.Password, result.Salt))
            {
                return true;
            }

            return false;
        }
    }
}
