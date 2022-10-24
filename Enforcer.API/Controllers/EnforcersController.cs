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

        [HttpGet("{id}")]
        public async Task<ActionResult<EnforcerDetailedDTO>> GetSingle(string id)
            => await _enforcersService.GetSingleAsync(id);

        [HttpPut("{id}/assign")]
        public async Task<IActionResult> AssignEnforcerAsync(string id, string crimeId)
        {
            await _enforcersService.AssingEnforcerAsync(crimeId, id);
            return Ok();
        }
    }
}
