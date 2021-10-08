using Microsoft.AspNetCore.Mvc;
using SWResistenceSocialNetwork.Application.Interfaces;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportRebelController : ControllerBase
    {
        private readonly IReportRebelService _reportRebelService;

        public ReportRebelController(IReportRebelService reportRebelService)
        {
            _reportRebelService = reportRebelService;
        }

        /// <summary>
        /// Reporta um rebelde como traidor
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Rebelde reportado com sucesso</response>
        [HttpPost]
        public async Task<IActionResult> Post(int rebelId)
        {
            await _reportRebelService.Report(rebelId);
            return Ok();
        }
    }
}
