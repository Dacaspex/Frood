using FroodServer.Exceptions;

namespace FroodServer.Services.Exceptions;

public class MoodCategoryNotFoundException(Guid moodCategoryId) : BadInputException(CreateMessage(moodCategoryId))
{
    private static string CreateMessage(Guid spaceId)
    {
        return $"Mood category with id '{spaceId.ToString()}' not found";
    }
}
