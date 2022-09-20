using Microsoft.AspNetCore.Authorization;
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
    public class NamesController : ControllerBase
    {
        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetNames()
        {
            var names = await Task.FromResult(new List<string> { "Adam", "Robert" });
            return Ok(names);
        }
    }
}
