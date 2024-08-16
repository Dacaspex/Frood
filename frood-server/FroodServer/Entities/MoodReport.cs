namespace FroodServer.Entities;

public class MoodReport : BaseEntity
{
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public float GlobalMood { get; set; } = 0.5f;

    public Guid PartnerId { get; set; }
    public Partner Partner { get; set; } = null!;

    public ICollection<MoodCategory> MoodCategories { get; } = new List<MoodCategory>();
}
