namespace FroodServer.Dtos.Request;

public class MoodCategoryUpdateDto
{
    public Guid Id { get; set; }
    public List<MoodTopicUpdateDto> MoodTopics { get; set; }
}
