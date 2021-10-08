namespace SWResistenceSocialNetwork.Application.DTO.Common
{
    public class RebelDto
    {
        public int Id { get; set; }
        public NameDto Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public GeoLocationDto GeoLocation { get; set; }
        public InventoryDto Inventory { get; set; }
    }
}
