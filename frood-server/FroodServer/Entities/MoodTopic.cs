using FroodServer.Model;

namespace FroodServer.Entities;

public class MoodTopic : BaseEntity
{
    public string Name { get; set; }
    public MoodValue Value { get; set; }

    public Guid MoodCategoryId { get; set; }
    public MoodCategory MoodCategory { get; set; } = null!;
}
