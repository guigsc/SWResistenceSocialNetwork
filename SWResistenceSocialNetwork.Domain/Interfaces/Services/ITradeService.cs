using SWResistenceSocialNetwork.Domain.Entities;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Domain.Interfaces.Services
{
    public interface ITradeService
    {
        Task Trade(int buyerRebelId, Inventory buyerTradeInventory, int sellerRebelId, Inventory sellerTradeInventory);
    }
}
