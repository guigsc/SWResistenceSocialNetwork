using Microsoft.AspNetCore.Mvc;
using SWResistenceSocialNetwork.Application.DTO.Trade;
using SWResistenceSocialNetwork.Application.Interfaces;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ITradeApplicationService _tradeApplicationService;

        public TradeController(ITradeApplicationService tradeApplicationService)
        {
            _tradeApplicationService = tradeApplicationService;
        }

        /// <summary>
        /// Solicita uma troca entre dois rebeldes
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Troca efetuada com sucesso</response>
        /// <response code="400">Erro ao realizar troca</response>
        [HttpPost]
        public async Task<IActionResult> Trade(TradeDto trade)
        {
            await _tradeApplicationService.Trade(trade);
            return Ok();
        }
    }
}
