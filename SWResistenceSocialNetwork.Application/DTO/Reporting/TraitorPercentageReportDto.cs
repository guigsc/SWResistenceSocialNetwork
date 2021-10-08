namespace SWResistenceSocialNetwork.Application.DTO.Reporting
{
    public class RebelPercentageReportDto
    {
        public RebelPercentageReportDto() { }

        public RebelPercentageReportDto(double percentage) 
        {
            RebelPercentage = percentage;
        }

        public double RebelPercentage { get; set; }
    }
}
