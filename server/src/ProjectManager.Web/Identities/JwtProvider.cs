using Microsoft.IdentityModel.Tokens;
using ProjectManager.Core.Entity;
using ProjectManager.Web.Settings;
using ProjectManager.Web.WebApiModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Web.Identities
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtSettings _jwtOptions;

        public JwtProvider(JwtSettings jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public JwtResponse GetJwtToken(User user)
        {
            var claim = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("username", user.UserName),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("dateOfBirth", user.DateOfBirth?.ToString("dd/MM/yyyy H:mm:ss zzz"))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.Now.AddMinutes(_jwtOptions.JwtExpireMinutes);

            var token = new JwtSecurityToken(
                    claims: claim,
                    expires: expireDate,
                    signingCredentials: credentials
                );

            return new JwtResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
