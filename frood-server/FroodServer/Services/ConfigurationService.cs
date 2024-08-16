using FroodServer.Dtos;
using FroodServer.Entities;
using FroodServer.Model;
using FroodServer.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FroodServer.Services;

public class ConfigurationService(FroodContext context)
{
    public async Task<Space> CreateSpace(string spaceName, string partnerName)
    {
        var space = FroodContext.Create(new Space
        {
            Name = spaceName,
            Partners =
            {
                FroodContext.Create(new Partner
                {
                    Name = partnerName,
                    Secret = Guid.NewGuid(),
                    MoodReport = FroodContext.Create<MoodReport>()
                })
            }
        });

        await context.Spaces.AddAsync(space);
        await context.SaveChangesAsync();

        return space;
    }

    public async Task<PartnerDto> CreatePartner(Guid spaceId, string partnerName)
    {
        var targetSpace = await context.Spaces
            .Include(s => s.Partners)
            .FirstOrDefaultAsync(s => s.Id == spaceId);
        if (targetSpace is null) throw new SpaceNotFoundException(spaceId);

        // Don't allow partners with the same name
        var partnerNameUnique =
            !targetSpace.Partners.Any(p => p.Name.Equals(partnerName, StringComparison.OrdinalIgnoreCase));
        if (!partnerNameUnique) throw new PartnerNameNotUniqueException(spaceId, partnerName);

        var partner = FroodContext.Create(new Partner
        {
            Name = partnerName,
            Secret = Guid.NewGuid(),
            MoodReport = FroodContext.Create<MoodReport>(),
            SpaceId = targetSpace.Id
        });

        context.Partners.Add(partner);

        await context.SaveChangesAsync();

        return DtoMapper.ToDto(partner);
    }

    public async Task<MoodCategoryDto> CreateMoodCategory(Guid partnerId, string moodCategoryName)
    {
        var targetMoodReport = context.MoodReports
            .FirstOrDefault(m => m.PartnerId == partnerId);
        if (targetMoodReport is null) throw new Exception();

        var moodCategory = FroodContext.Create(new MoodCategory
        {
            MoodReportId = targetMoodReport.Id,
            Name = moodCategoryName
        });

        context.MoodCategories.Add(moodCategory);
        await context.SaveChangesAsync();

        return DtoMapper.ToDto(moodCategory);
    }

    public async Task EditMoodCategory(Guid moodCategoryId, string moodCategoryName)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteMoodCategory(Guid moodCategoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<MoodTopic> CreateMoodTopic(Guid moodCategoryId, string moodTopicName)
    {
        var targetMoodCategory = context.MoodCategories
            .Include(m => m.MoodTopics)
            .FirstOrDefault(m => m.Id == moodCategoryId);
        if (targetMoodCategory is null) throw new Exception();

        var moodTopic = FroodContext.Create(new MoodTopic
        {
            MoodCategoryId = targetMoodCategory.Id,
            Name = moodTopicName,
            Value = MoodValue.Indifferent
        });

        context.MoodTopics.Add(moodTopic);
        await context.SaveChangesAsync();

        return moodTopic;
    }
}
