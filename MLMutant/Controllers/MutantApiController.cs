using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLMutant.Services;
using MLMutant.Models;

namespace MLMutant.Controllers
{
    [Route("Mutant")]
    [ApiController]
    public class MutantApiController : ControllerBase
    {
        private readonly IMutantDetectorService _mutantDetectorService;

        public MutantApiController(IMutantDetectorService shoppingListService)
        {
            _mutantDetectorService = shoppingListService;
        }

        [HttpPost]
        public IActionResult isMutant([FromBody] Mutant mutant)
        {
            bool IsMutant = _mutantDetectorService.IsMutant(mutant.DNA);
            if (IsMutant)
                return Ok();
            else
                return StatusCode(403);
        }
    }
}
