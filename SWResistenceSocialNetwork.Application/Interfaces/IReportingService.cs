using SWResistenceSocialNetwork.Application.DTO.Reporting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Application.Interfaces
{
    public interface IReportingService
    {
        Task<TraitorPercentageReportDto> GetTraitorsPercentage();
        Task<RebelPercentageReportDto> GetNonTraitorsPercentage();
        Task<IEnumerable<AverageResourceTypePerRebelReportDto>> GetAverageResourceTypePerRebel();
        Task<PointsLostDueToTraitorsReportDto> GetPointsLostDueToTraitors();
    }
}
