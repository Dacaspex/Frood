namespace FroodServer.Dtos;

public class MoodCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MoodTopicDto> MoodTopics { get; set; }
}
