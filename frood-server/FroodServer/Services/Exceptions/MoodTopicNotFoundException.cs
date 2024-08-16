using FroodServer.Exceptions;

namespace FroodServer.Services.Exceptions;

public class MoodTopicNotFoundException(Guid spaceId) : BadInputException(CreateMessage(spaceId))
{
    private static string CreateMessage(Guid moodTopicId)
    {
        return $"Mood topic with id '{moodTopicId.ToString()}' not found";
    }
}
