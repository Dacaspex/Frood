namespace FroodServer.Dtos;

public class PartnerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MoodReportDto MoodReport { get; set; }
}
