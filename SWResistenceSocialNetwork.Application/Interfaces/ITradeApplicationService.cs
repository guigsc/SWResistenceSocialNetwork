using SWResistenceSocialNetwork.Application.DTO.Trade;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Application.Interfaces
{
    public interface ITradeApplicationService
    {
        Task Trade(TradeDto trade);
    }
}
