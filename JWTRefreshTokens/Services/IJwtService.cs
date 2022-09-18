using JWTRefreshTokens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTRefreshTokens.Services
{
    public interface IJwtService
    {
        Task<string> GetTokenAsync(AuthRequest authRequest);
    }
}
