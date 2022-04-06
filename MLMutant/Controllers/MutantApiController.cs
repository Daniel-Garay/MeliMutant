using Microsoft.AspNetCore.Mvc;
using MLMutant.Services;
using MLMutant.Models.ApiModels;
namespace MLMutant.Controllers
{

    [ApiController]
    public class MutantApiController : ControllerBase
    {
        private readonly IDynamoDB _dynamoDB;
        private readonly IMapper _mapper;
        public MutantApiController(IDynamoDB dynamoDB, IMapper mapper)
        {
            _dynamoDB = dynamoDB;
            _mapper = mapper;
        }
        [Route("Mutant")]
        [HttpPost]
        public IActionResult isMutant([FromBody] Mutant mutant)
        {
            var newMutant = _mapper.convert(mutant);
            _dynamoDB.CreateMutant(newMutant);
            _dynamoDB.UpdateStats(newMutant.IsMutant);
            if (newMutant.IsMutant)
                return Ok();
            else
                return StatusCode(403);
        }
        [Route("stats")]
        [HttpGet]
        public async Task<IActionResult> stats()
        {
            return Ok(await _dynamoDB.GetMutantStats());
        }
    }
}