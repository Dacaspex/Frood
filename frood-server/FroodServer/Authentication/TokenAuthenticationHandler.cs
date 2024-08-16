using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using AuthenticationService = FroodServer.Services.AuthenticationService;

namespace FroodServer.Authentication;

public class TokenAuthenticationHandler(
    AuthenticationService authenticationService,
    IOptionsMonitor<TokenAuthenticationOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder)
    : AuthenticationHandler<TokenAuthenticationOptions>(options, logger, encoder)
{
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // Check headers
        if (!Request.Headers.ContainsKey(Options.SpaceTokenName))
        {
            return AuthenticateResult.Fail($"Missing header: {Options.SpaceTokenName}");
        }

        if (!Request.Headers.ContainsKey(Options.PartnerSecretTokenName))
        {
            return AuthenticateResult.Fail($"Missing header: {Options.PartnerSecretTokenName}");
        }

        // Get tokens
        var spaceId = Guid.Parse(Request.Headers[Options.SpaceTokenName]!);
        var partnerSecret = Guid.Parse(Request.Headers[Options.PartnerSecretTokenName]!);

        var authenticationSuccess = await authenticationService.VerifyLogin(spaceId, partnerSecret);
        if (!authenticationSuccess)
        {
            return AuthenticateResult.Fail("Invalid tokens");
        }

        // Success
        var claims = new List<Claim>
        {
            new("Authenticated", "true")
        };
        var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
    }
}

public class TokenAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "TokenAuthenticationScheme";

    public string SpaceTokenName { get; } = "X-SpaceId";
    public string PartnerSecretTokenName { get; } = "X-PartnerSecret";
}
