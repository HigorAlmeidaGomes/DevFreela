using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DevFreela.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenarateJwtToken(string email, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];

            var audience = _configuration["Jwt:Audience"];

            var key = _configuration["Jwt:Key"];

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("UserName",email),
                new Claim(ClaimTypes.Role,role),
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials,
                claims: claims);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
        public string ComputeSha256Has(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
