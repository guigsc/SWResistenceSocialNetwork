using Microsoft.AspNetCore.Mvc;
using SWResistenceSocialNetwork.Application.Interfaces;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsLostDueToTraitorsReportController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public PointsLostDueToTraitorsReportController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        /// <summary>
        /// Relatório que calcula os pontos perdidos devido aos traidores.
        /// </summary>
        /// <returns>pontos perdidos devido aos traidores</returns>
        /// <response code="200">Retorna os pontos perdidos devido aos traidores</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _reportingService.GetPointsLostDueToTraitors());
        }
    }
}
