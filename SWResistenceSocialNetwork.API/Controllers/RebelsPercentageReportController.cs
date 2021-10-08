using Microsoft.AspNetCore.Mvc;
using SWResistenceSocialNetwork.Application.Interfaces;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RebelsPercentageReportController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public RebelsPercentageReportController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        /// <summary>
        /// Relatório que calcula a porcentagem de rebeldes.
        /// </summary>
        /// <returns>porcentagem de rebeldes</returns>
        /// <response code="200">Retorna a porcentagem de rebeldes</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _reportingService.GetNonTraitorsPercentage());
        }
    }
}
