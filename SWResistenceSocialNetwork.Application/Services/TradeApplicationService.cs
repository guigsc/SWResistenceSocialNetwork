using AutoMapper;
using SWResistenceSocialNetwork.Application.DTO.Trade;
using SWResistenceSocialNetwork.Application.Interfaces;
using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using SWResistenceSocialNetwork.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Application.Services
{
    public class TradeApplicationService : ITradeApplicationService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ITradeService _tradeService;
        private readonly IMapper _mapper;

        public TradeApplicationService(
            IItemRepository itemRepository, 
            ITradeService tradeService,
            IMapper mapper)
        {
            _itemRepository = itemRepository;
            _tradeService = tradeService;
            _mapper = mapper;
        }

        public async Task Trade(TradeDto trade)
        {
            var buyerInventory = _mapper.Map<Inventory>(trade.BuyerTradeInventory);
            var sellerInventory = _mapper.Map<Inventory>(trade.SellerTradeInventory);

            await LoadItems(buyerInventory);
            await LoadItems(sellerInventory);

            await _tradeService.Trade(trade.BuyerRebelId, buyerInventory, trade.SellerRebelId, sellerInventory);
        }

        private async Task LoadItems(Inventory inventory)
        {
            foreach (var item in inventory.Items)
                item.LoadItem(await _itemRepository.GetByIdAsync(item.ItemId));
        }
    }
}
