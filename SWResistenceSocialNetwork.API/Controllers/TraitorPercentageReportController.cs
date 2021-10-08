using Microsoft.AspNetCore.Mvc;
using SWResistenceSocialNetwork.Application.Interfaces;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraitorPercentageReportController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public TraitorPercentageReportController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        /// <summary>
        /// Relatório que calcula a porcentagem de traidores.
        /// </summary>
        /// <returns>porcentagem de traidores</returns>
        /// <response code="200">Retorna a porcentagem de traidores</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _reportingService.GetTraitorsPercentage());
        }
    }
}
