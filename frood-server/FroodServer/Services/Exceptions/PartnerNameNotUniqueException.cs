using FroodServer.Exceptions;

namespace FroodServer.Services.Exceptions;

public class PartnerNameNotUniqueException(Guid spaceId, string partnerName)
    : BadInputException(CreateMessage(spaceId, partnerName))
{
    private static string CreateMessage(Guid spaceId, string partnerName)
    {
        return $"A partner with name '{partnerName}' already exists in the space '{spaceId.ToString()}'";
    }
}
