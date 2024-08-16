namespace FroodServer.Controllers.Requests;

public record LoginRequest(Guid SpaceId, Guid PartnerSecret);
