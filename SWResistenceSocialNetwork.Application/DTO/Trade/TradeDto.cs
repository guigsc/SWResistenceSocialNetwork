using SWResistenceSocialNetwork.Application.DTO.Common;

namespace SWResistenceSocialNetwork.Application.DTO.Trade
{
    public class TradeDto
    {
        public int BuyerRebelId { get; set; }
        public InventoryDto BuyerTradeInventory { get; set; }
        public int SellerRebelId { get; set; }
        public InventoryDto SellerTradeInventory { get; set; }
    }
}
