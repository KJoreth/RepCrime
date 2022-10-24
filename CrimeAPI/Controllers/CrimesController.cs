
using CrimeAPI.Data.Enums;

namespace CrimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimesController : ControllerBase
    {
        private readonly ICrimesService _crimesService;
        public CrimesController(ICrimesService crimesService)
            => _crimesService = crimesService;

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
    }
}
