using FroodServer.Exceptions;

namespace FroodServer.Services.Exceptions;

public class SpaceNotFoundException(Guid spaceId) : BadInputException(CreateMessage(spaceId))
{
    private static string CreateMessage(Guid spaceId)
    {
        return $"Space with id '{spaceId.ToString()}' not found";
    }
}
