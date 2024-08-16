using FroodServer.Controllers.Requests;
using FroodServer.Dtos;
using FroodServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FroodServer.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController(ApiService apiService) : ControllerBase
{
    [HttpGet("space/{spaceId:guid}")]
    [Authorize]
    [ProducesResponseType<SpaceDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSpace(Guid spaceId)
    {
        var space = await apiService.GetSpace(spaceId);

        return Ok(space);
    }

    [HttpPatch( "space/{spaceId:guid}/moodReport")]
    [Authorize]
    public async Task<IActionResult> UpdateMoodReport(Guid spaceId, [FromBody] UpdateMoodReportRequest request)
    {
        await apiService.UpdateMoodReport(spaceId, request.PartnerId, request.MoodReport);
        return Ok();
    }
}
