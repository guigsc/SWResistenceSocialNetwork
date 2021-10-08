using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Application.Interfaces
{
    public interface IReportRebelService
    {
        Task Report(int rebelId);
    }
}
