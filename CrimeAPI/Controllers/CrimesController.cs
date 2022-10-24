namespace CrimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimesController : ControllerBase
    {
        private readonly ICrimesService _crimesService;
        public CrimesController(ICrimesService crimesService)
            => _crimesService = crimesService;

        [HttpGet]
        public async Task<List<CrimeSimpleDTO>> GetAllAsync()
            => await _crimesService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<CrimeDetailedDTO>> GetSingleAsync(string id)
        {
            if(ObjectId.TryParse(id, out _))
                return await _crimesService.GetSingleAsync(id);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewAsync(CrimeCreateDTO model)
        {
            if (ModelState.IsValid && Enum.IsDefined(typeof(CrimeTypes), model.CrimeType))
            {
                var crime = await _crimesService.CreateAsync(model);
                return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{crime.Id}", crime);
            }
            return BadRequest();
        }

        [HttpPut("{id}/assign")]
        public async Task<IActionResult> AssignEnforcerAsync(string id, AssignRequest request)
        {
            await _crimesService.AssingEnforcerAsync(id, request);
            return Ok();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateCrimeStatusAsync(string id, CrimeStatus crimeStatus)
        {
            await _crimesService.UpdateCrimeStatusAsync(id, crimeStatus);
            return Ok();
        }

    }
}
