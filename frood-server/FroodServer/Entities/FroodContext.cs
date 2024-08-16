using Microsoft.EntityFrameworkCore;

namespace FroodServer.Entities;

public class FroodContext : DbContext
{
    public FroodContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Space> Spaces { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<MoodReport> MoodReports { get; set; }
    public DbSet<MoodCategory> MoodCategories { get; set; }
    public DbSet<MoodTopic> MoodTopics { get; set; }

    public static T Create<T>(T entity) where T : BaseEntity
    {
        entity.Id = Guid.NewGuid();
        return entity;
    }

    public static T Create<T>() where T : BaseEntity, new()
    {
        return Create(new T());
    }
}
