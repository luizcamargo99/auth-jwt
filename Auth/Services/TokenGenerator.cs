using Auth.Constants;
using Auth.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Services
{
    public class TokenGenerator
    {
        private readonly DateTime _expiresTime = DateTime.Now.AddDays(1);

        public string Generate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();            

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstant.Secret)), SecurityAlgorithms.HmacSha256Signature),
                Expires = _expiresTime
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
