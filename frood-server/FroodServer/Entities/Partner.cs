namespace FroodServer.Entities;

public class Partner : BaseEntity
{
    public string Name { get; set; }
    public Guid Secret { get; set; }

    public Guid SpaceId { get; set; }
    public Space Space { get; set; } = null!;

    public MoodReport MoodReport { get; set; } = null!;
}
