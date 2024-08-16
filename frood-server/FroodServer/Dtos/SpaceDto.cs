namespace FroodServer.Dtos;

public class SpaceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<PartnerDto> Partners { get; set; }
    public List<MoodCategoryDto> MoodCategories { get; set; }
}
