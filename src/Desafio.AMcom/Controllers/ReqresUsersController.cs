using Desafio.AMcom.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Desafio.AMcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReqresUsersController : ControllerBase
    {
        private readonly IReqresUsersService _webService;

        public ReqresUsersController(IReqresUsersService webService)
        {
            _webService = webService;
        }

        [HttpGet("users")]
        public async Task<ActionResult> RetornaUruarios([FromQuery] int page = 1, [FromQuery] int pageSize = 6)
        {
            var users = await _webService.GetUsers(page, pageSize);
            return Ok(users);
        }
    }
}
