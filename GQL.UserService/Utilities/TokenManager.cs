using GQL.UserService.Config;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GQL.UserService.Utilities
{
    public static class TokenManager
    {
        public static string GenerateToken(Guid userId, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userId.ToString())
                    }
                ),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string GenerateToken(string userId, string secret)
        {
            Guid guid;
            if (Guid.TryParse(userId, out guid))
                return GenerateToken(guid, secret);
            else
                throw new ArgumentException($"Invalid user id: { userId }");
        }
    }
}
