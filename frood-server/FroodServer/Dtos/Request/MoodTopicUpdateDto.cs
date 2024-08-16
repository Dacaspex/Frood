using FroodServer.Model;

namespace FroodServer.Dtos.Request;

public class MoodTopicUpdateDto
{
    public Guid Id { get; set; }
    public MoodValue Value { get; set; }
}
