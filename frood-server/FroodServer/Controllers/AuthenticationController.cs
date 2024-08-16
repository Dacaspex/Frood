using FroodServer.Controllers.Requests;
using FroodServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FroodServer.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(AuthenticationService authenticationService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var loginSuccess = await authenticationService.VerifyLogin(request.SpaceId, request.PartnerSecret);
        if (loginSuccess) return Ok();
        return Unauthorized();
    }
}
