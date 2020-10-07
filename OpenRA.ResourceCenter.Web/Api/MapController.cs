using Microsoft.AspNetCore.Mvc;

namespace OpenRA.ResourceCenter.Web.Api
{
    [ApiController]
    [Route("[controller]")]
    public class MapController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMap()
        {
            return Ok();
        }
    }
}