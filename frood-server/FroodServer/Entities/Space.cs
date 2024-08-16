namespace FroodServer.Entities;

public class Space : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Partner> Partners { get; } = new List<Partner>();
}
