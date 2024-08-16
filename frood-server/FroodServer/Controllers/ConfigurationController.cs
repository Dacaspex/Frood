using FroodServer.Controllers.Requests;
using FroodServer.Dtos;
using FroodServer.Entities;
using FroodServer.Exceptions;
using FroodServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FroodServer.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigurationController(
    AuthenticationService authenticationService,
    ConfigurationService configurationService) : ControllerBase
{
    [HttpPost("space")]
    [ProducesResponseType<Space>(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateSpace([FromBody] CreateSpaceRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.SpaceName))
        {
            return BadRequest($"{nameof(CreateSpaceRequest.SpaceName)} cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(request.PartnerName))
        {
            return BadRequest($"{nameof(CreateSpaceRequest.PartnerName)} cannot be empty");
        }

        var space = await configurationService.CreateSpace(request.SpaceName, request.PartnerName);

        return Ok(space);
    }

    [HttpPost("space/{spaceId:guid}/partners")]
    [Authorize]
    public async Task<IActionResult> CreatePartner(Guid spaceId, [FromBody] CreatePartnerRequest request)
    {
        try
        {
            var partner = await configurationService.CreatePartner(spaceId, request.PartnerName);
            return Ok(partner);
        }
        catch (BadInputException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("moodCategory")]
    [ProducesResponseType<MoodCategoryDto>(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateMoodCategory([FromBody] CreateMoodCategoryRequest request)
    {
        var moodCategory = await configurationService.CreateMoodCategory(request.PartnerId, request.MoodCategoryName);

        return Ok(moodCategory);
    }

    [HttpPatch]
    public async Task<IActionResult> EditMoodCategory()
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMoodCategory()
    {
        return Ok();
    }

    [HttpPost("moodTopic")]
    [ProducesResponseType<MoodTopicDto>(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateMoodTopic(CreateMoodTopicRequest request)
    {
        var moodTopic = await configurationService.CreateMoodTopic(request.MoodCategoryId, request.MoodTopicName);

        return Ok(moodTopic);
    }
}
