using JWTRefreshTokens.Context;
using JWTRefreshTokens.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace JWTRefreshTokens.Services
{
    public class JwtService : IJwtService
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;

        public JwtService(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> GetTokenAsync(AuthRequest authRequest)
        {
            var user = _context.Users.FirstOrDefault(user => user.UserName.Equals(authRequest.UserName)
                        && user.Password.Equals(authRequest.Password));
            if (user == null)
                return await Task.FromResult<string>(null);

            var jwtKey = _configuration.GetValue<string>("JwtSettings:Key");
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);

            var tokenhandler = new JwtSecurityTokenHandler();

            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddSeconds(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256)
            };

            var token = tokenhandler.CreateToken(descriptor);
            return await Task.FromResult(tokenhandler.WriteToken(token));
        }
    }
}
