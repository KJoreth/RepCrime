using Microsoft.AspNetCore.Mvc;

namespace EnforcerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnforcersController : ControllerBase
    {
        private readonly IEnforcersService _enforcersService;
        public EnforcersController(IEnforcersService enforcersService)
            => _enforcersService = enforcersService;

        [HttpGet]
        public async Task<ActionResult<List<EnforcerSimpleDTO>>> GetAllAsync()
            => await _enforcersService.GetAllAsync();
    }
}
