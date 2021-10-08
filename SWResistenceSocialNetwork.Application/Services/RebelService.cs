using AutoMapper;
using SWResistenceSocialNetwork.Application.DTO.Common;
using SWResistenceSocialNetwork.Application.Interfaces;
using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWResistenceSocialNetwork.Application.Services
{
    public class RebelService : IRebelService
    {
        private readonly IRebelRepository _repository;
        private readonly IMapper _mapper;
        
        public RebelService(IRebelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RebelDto> AddAsync(RebelDto rebelDTO)
        {
            var rebel = await _repository.AddAsync(_mapper.Map<Rebel>(rebelDTO));
            return _mapper.Map<RebelDto>(rebel);
        }

        public async Task<IEnumerable<RebelDto>> ListAsync()
        {
            var rebels = await _repository.ListAsync();
            return _mapper.Map<IEnumerable<RebelDto>>(rebels);
        }

        public async Task UpdateGeoLocation(int id, GeoLocationDto geoLocation)
        {
            var rebel = await _repository.GetByIdAsync(id);

            rebel.UpdateGeoLocation(geoLocation.Latitude, geoLocation.Longitude, geoLocation.Name);

            await _repository.UpdateAsync(rebel);
        }
    }
}
