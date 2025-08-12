using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet,Authorize]
        public async Task<IActionResult> HomePage()
        {
            string? name = User?.Identity?.Name;
            return Ok($"Welcome {name}");
        }
    }
}
