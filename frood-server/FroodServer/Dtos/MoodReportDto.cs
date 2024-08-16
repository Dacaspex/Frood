namespace FroodServer.Dtos;

public class MoodReportDto
{
    public DateTime UpdatedAt { get; set; }
    public float GlobalMood { get; set; }
    public List<MoodCategoryDto> MoodCategories { get; set; }
}
