using FroodServer.Exceptions;

namespace FroodServer.Services.Exceptions;

public class PartnerNotFoundException(Guid partnerId) : BadInputException(CreateMessage(partnerId))
{
    private static string CreateMessage(Guid partnerId)
    {
        return $"Partner with id '{partnerId.ToString()}' not found";
    }
}
