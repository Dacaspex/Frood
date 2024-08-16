namespace FroodServer.Entities;

public class MoodCategory : BaseEntity
{
    public string Name { get; set; }

    public ICollection<MoodTopic> MoodTopics { get; } = new List<MoodTopic>();

    public Guid MoodReportId { get; set; }
    public MoodReport MoodReport { get; set; } = null!;
}
