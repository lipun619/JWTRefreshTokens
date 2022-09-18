using JWTRefreshTokens.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTRefreshTokens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> AuthToken([FromBody] AuthRequest authRequest)
        {
            return null;
        }
    }
}
