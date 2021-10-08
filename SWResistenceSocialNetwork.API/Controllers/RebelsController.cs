using Microsoft.AspNetCore.Mvc;
using SWResistenceSocialNetwork.Application.DTO.Common;
using SWResistenceSocialNetwork.Application.Interfaces;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RebelsController : ControllerBase
    {
        private readonly IRebelService _rebelService;

        public RebelsController(IRebelService rebelService)
        {
            _rebelService = rebelService;
        }

        /// <summary>
        /// Lista todos os rebeldes cadastrados.
        /// </summary>
        /// <returns>lista de rebeldes cadastrados</returns>
        /// <response code="200">Retorna a lista de rebeldes cadastrados</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _rebelService.ListAsync());
        }

        /// <summary>
        /// Cria um novo rebelde
        /// </summary>
        /// <returns>rebelde cadastrado</returns>
        /// <response code="200">Retorna o rebelde cadastrado</response>
        /// <response code="400">Erro ao criar rebelde</response>
        [HttpPost]
        public async Task<IActionResult> Post(RebelDto rebel)
        {
            return Ok(await _rebelService.AddAsync(rebel));
        }

        /// <summary>
        /// Altera a geolocalizacao de um rebelde
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Geolocalizacao alterada com sucesso</response>
        /// <response code="400">Erro ao alterar geolocalizacao</response>
        [HttpPut]
        public async Task<IActionResult> Put(int id, GeoLocationDto geoLocation)
        {
            await _rebelService.UpdateGeoLocation(id, geoLocation);
            return Ok();
        }
    }
}
