using Microsoft.AspNetCore.Mvc;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        /// <summary>
        /// Lista todos os itens cadastrados
        /// </summary>
        /// <returns>lista de itens cadastrados</returns>
        /// <response code="200">Retorna a lista de itens cadastrados</response>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _itemRepository.ListAsync());
        }
    }
}
