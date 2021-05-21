using Microsoft.AspNetCore.Mvc;

namespace ToSoftware.Shop.Catalog.Api.Controllers.Default
{
    [Route("")]
    [ApiController]
    public class MeController : ControllerBase
    {
        [HttpGet, Route("")]
        public IActionResult Get() => Ok(new { name = "shop catalog", version = "1.0" });
    }
}