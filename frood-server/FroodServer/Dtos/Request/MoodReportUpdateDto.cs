namespace FroodServer.Dtos.Request;

public class MoodReportUpdateDto
{
    public float GlobalMood { get; set; }
    public List<MoodCategoryUpdateDto> MoodCategories { get; set; }
}
