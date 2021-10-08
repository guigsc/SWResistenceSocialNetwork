using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using SWResistenceSocialNetwork.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Domain.Services
{
    public class TradeService : ITradeService
    {
        private readonly IRebelRepository _rebelRepository;

        public TradeService(IRebelRepository rebelRepository)
        {
            _rebelRepository = rebelRepository;
        }

        public async Task Trade(int buyerRebelId, Inventory buyerTradeInventory, int sellerRebelId, Inventory sellerTradeInventory)
        {
            var buyerRebel = await _rebelRepository.GetByIdAsync(buyerRebelId);
            var sellerRebel = await _rebelRepository.GetByIdAsync(sellerRebelId);

            if (!buyerRebel.CanTrade(buyerTradeInventory.Items) || !sellerRebel.CanTrade(sellerTradeInventory.Items))
                throw new System.Exception("Buyer or seller can't trade");

            if (!buyerTradeInventory.IsTradePossible(sellerTradeInventory)) 
                throw new System.Exception("Trade is not possible");

            buyerRebel.TakeItems(buyerTradeInventory.Items);
            sellerRebel.TakeItems(sellerTradeInventory.Items);

            buyerRebel.AddItems(sellerTradeInventory.Items);
            sellerRebel.AddItems(buyerTradeInventory.Items);

            await _rebelRepository.UpdateAsync(buyerRebel);
            await _rebelRepository.UpdateAsync(sellerRebel);
        }
    }
}
