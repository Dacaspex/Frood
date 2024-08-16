using FroodServer.Model;

namespace FroodServer.Dtos;

public class MoodTopicDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MoodValue Value { get; set; }
}
