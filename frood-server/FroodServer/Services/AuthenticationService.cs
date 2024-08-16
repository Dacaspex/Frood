using FroodServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FroodServer.Services;

public class AuthenticationService(FroodContext context)
{
    public async Task<bool> VerifyLogin(Guid spaceId, Guid partnerSecret)
    {
        var space = await context.Spaces
            .Include(s => s.Partners)
            .FirstOrDefaultAsync(s => s.Id == spaceId);
        if (space is null) return false;

        var partnerExists = space.Partners.Any(p => p.Secret == partnerSecret);
        return partnerExists;
    }
}
