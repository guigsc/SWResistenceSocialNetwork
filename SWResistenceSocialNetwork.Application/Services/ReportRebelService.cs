using SWResistenceSocialNetwork.Application.Interfaces;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Application.Services
{
    public class ReportRebelService : IReportRebelService
    {
        private readonly IRebelRepository _repository;
        
        public ReportRebelService(IRebelRepository repository)
        {
            _repository = repository;
        }

        public async Task Report(int rebelId)
        {
            var rebel = await _repository.GetByIdAsync(rebelId);

            rebel.ReportAsTraitor();

            await _repository.UpdateAsync(rebel);
        }
    }
}
