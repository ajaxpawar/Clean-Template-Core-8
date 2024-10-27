using Api.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : BaseApiController
    {

        [HttpPost("test-endpoint")]
        public async Task<IActionResult> TestEndpoint(dynamic request)
        {


            return Ok(request);
        }

    }
}
