namespace SWResistenceSocialNetwork.Application.DTO.Reporting
{
    public class PointsLostDueToTraitorsReportDto
    {
        public PointsLostDueToTraitorsReportDto() { }

        public PointsLostDueToTraitorsReportDto(int points)
        {
            Points = points; 
        }

        public int Points { get; set; }
    }
}
