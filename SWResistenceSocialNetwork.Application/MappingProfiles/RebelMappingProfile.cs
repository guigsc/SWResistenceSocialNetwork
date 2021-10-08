using AutoMapper;
using SWResistenceSocialNetwork.Application.DTO.Common;
using SWResistenceSocialNetwork.Domain.Entities;
using SWResistenceSocialNetwork.Domain.ValueObjects;

namespace SWResistenceSocialNetwork.Application.MappingProfiles
{
    public class RebelMappingProfile : Profile
    {
        public RebelMappingProfile()
        {
            CreateMap<Rebel, RebelDto>().ReverseMap();
            CreateMap<GeoLocation, GeoLocationDto>().ReverseMap();
            CreateMap<Name, NameDto>().ReverseMap();
            CreateMap<InventoryItem, InventoryItemDto>().ReverseMap();
            CreateMap<Inventory, InventoryDto>().ReverseMap();
        }
    }
}
