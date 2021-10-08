using Microsoft.AspNetCore.Mvc;
using SWResistenceSocialNetwork.Application.Interfaces;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AverageResourceTypePerRebelController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public AverageResourceTypePerRebelController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        /// <summary>
        /// Relatório que calcula a média de tipos de recurso por rebelde.
        /// </summary>
        /// <returns>média de tipos de recurso por rebelde</returns>
        /// <response code="200">Retorna a média de tipos de recurso por rebelde</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _reportingService.GetAverageResourceTypePerRebel());
        }
    }
}
