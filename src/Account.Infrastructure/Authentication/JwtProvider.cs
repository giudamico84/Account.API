using Account.Domain.Common;
using Account.Domain.Entities;
using Account.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        public async Task<Result<string>> Generate(User user)
        {
            var claims = new Claim[] { };

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret-key")), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "issuer",
                audience: "audience",
                claims: claims,
                null,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
