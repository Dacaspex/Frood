using FroodServer.Dtos;
using FroodServer.Dtos.Request;
using FroodServer.Entities;
using FroodServer.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FroodServer.Services;

public class ApiService(FroodContext context)
{
    public async Task<SpaceDto> GetSpace(Guid spaceId)
    {
        var space = await context.Spaces
            .Include(s => s.Partners)
            .ThenInclude(p => p.MoodReport)
            .ThenInclude(m => m.MoodCategories)
            .ThenInclude(c => c.MoodTopics)
            .FirstOrDefaultAsync(s => s.Id == spaceId);
        if (space is null) throw new Exception(); // TODO: Space doesn't exist

        return DtoMapper.ToDto(space);
    }

    public async Task<List<PartnerDto>> GetPartners(Guid spaceId)
    {
        // Check if space exists
        var space = await context.Spaces.FirstOrDefaultAsync(s => s.Id == spaceId);
        if (space is null) throw new SpaceNotFoundException(spaceId);

        var partners = await context.Partners
            .Include(p => p.MoodReport)
            .ThenInclude(m => m.MoodCategories)
            .ThenInclude(c => c.MoodTopics)
            .Where(p => p.SpaceId == spaceId)
            .ToListAsync();

        return DtoMapper.ToDto(partners);
    }

    public async Task UpdateMoodReport(Guid spaceId, Guid partnerId, MoodReportUpdateDto moodReport)
    {
        var space = await context.Spaces.FirstOrDefaultAsync(s => s.Id == spaceId);
        if (space is null) throw new SpaceNotFoundException(spaceId);

        var partner = await context.Partners
            .Include(p => p.MoodReport)
            .ThenInclude(m => m.MoodCategories)
            .ThenInclude(c => c.MoodTopics)
            .Where(p => p.Id == partnerId)
            .FirstOrDefaultAsync();
        if (partner is null) throw new PartnerNotFoundException(partnerId);

        partner.MoodReport.GlobalMood = moodReport.GlobalMood;
        foreach (var moodCategory in moodReport.MoodCategories)
        {
            var targetMoodCategory = partner.MoodReport.MoodCategories.FirstOrDefault(c => c.Id == moodCategory.Id);
            if (targetMoodCategory is null) throw new MoodCategoryNotFoundException(moodCategory.Id);

            foreach (var moodTopic in moodCategory.MoodTopics)
            {
                var targetMoodTopic = targetMoodCategory.MoodTopics.FirstOrDefault(t => t.Id == moodTopic.Id);
                if (targetMoodTopic is null) throw new MoodTopicNotFoundException(moodTopic.Id);

                targetMoodTopic.Value = moodTopic.Value;
            }
        }

        await context.SaveChangesAsync();
    }
}
