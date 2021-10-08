namespace SWResistenceSocialNetwork.Application.DTO.Reporting
{
    public class TraitorPercentageReportDto
    {
        public TraitorPercentageReportDto() { }

        public TraitorPercentageReportDto(double percentage) 
        {
            TraitorPercentage = percentage;
        }

        public double TraitorPercentage { get; set; }
    }
}
