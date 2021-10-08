using SWResistenceSocialNetwork.Application.DTO.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Application.Interfaces
{
    public interface IRebelService
    {
        Task<RebelDto> AddAsync(RebelDto rebelDTO);
        Task<IEnumerable<RebelDto>> ListAsync();
        Task UpdateGeoLocation(int id, GeoLocationDto geoLocation);
    }
}
