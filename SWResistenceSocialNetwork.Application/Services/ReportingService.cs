using SWResistenceSocialNetwork.Application.DTO.Reporting;
using SWResistenceSocialNetwork.Application.Interfaces;
using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Application.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IRebelRepository _rebelRepository;
        private readonly IItemRepository _itemRepository;

        public ReportingService(IRebelRepository rebelRepository, IItemRepository itemRepository)
        {
            _rebelRepository = rebelRepository;
            _itemRepository = itemRepository;
        }

        public async Task<TraitorPercentageReportDto> GetTraitorsPercentage()
        {
            int traitorsCount = await _rebelRepository.GetTraitorsCountAsync();
            int rebelsCount = await _rebelRepository.GetRebelsCountAsync();

            double percentage = traitorsCount / (double)rebelsCount * 100;

            return new TraitorPercentageReportDto(percentage);
        }

        public async Task<RebelPercentageReportDto> GetNonTraitorsPercentage()
        {
            int nonTraitorsCount = await _rebelRepository.GetNonTraitorsCountAsync();
            int rebelsCount = await _rebelRepository.GetRebelsCountAsync();

            double percentage = nonTraitorsCount / (double)rebelsCount * 100;

            return new RebelPercentageReportDto(percentage);
        }

        public async Task<IEnumerable<AverageResourceTypePerRebelReportDto>> GetAverageResourceTypePerRebel()
        {
            var rebels = await _rebelRepository.ListAsync();

            var result = await Task.WhenAll(rebels
                .SelectMany(rebel => rebel.Inventory.Items)
                .GroupBy(item => item.ItemId)
                .Select(async group => await GetResourceAverage(group)));

            return result.ToList();
        }

        public async Task<PointsLostDueToTraitorsReportDto> GetPointsLostDueToTraitors()
        {
            var traitors = await _rebelRepository.ListTraitorsAsync();

            int points = traitors.Sum(traitor => traitor.Inventory.CalculatePoints());
            
            return new PointsLostDueToTraitorsReportDto(points);
        }

        private async Task<AverageResourceTypePerRebelReportDto> GetResourceAverage(IGrouping<int, InventoryItem> group)
        {
            var item = await _itemRepository.GetByIdAsync(group.Key);
            
            int rebelsCount = await _rebelRepository.GetRebelsCountAsync();
            
            double average = group.Sum(item => item.Quantity) / (double)rebelsCount;

            return new AverageResourceTypePerRebelReportDto
            {
                Average = average,
                ItemId = item.Id,
                ItemName = item.Name
            };
        }
    }
}
