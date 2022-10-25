
namespace StatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;
        public StatsController(IStatsService statsService)
            => _statsService = statsService;

        [HttpPost("CrimeUp")]
        public async Task<ActionResult> RiseCrimeCounterAsync()
        {
            await _statsService.RiseCrimeCounterAsync();
            return Ok();
        }

        [HttpPost("EnforcerUp")]
        public async Task<ActionResult> RiseCrimeEnforcerCounterAsync()
        {
            await _statsService.RiseEnforcerCounterAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<StatsDTO>> GetTodayStatsAsync()
        {
            var stats = await _statsService.GetTodayStatsAsync();
            return Ok(stats);
        }
    }
}
