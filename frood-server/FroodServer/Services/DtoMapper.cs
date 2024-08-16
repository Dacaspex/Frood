using FroodServer.Dtos;
using FroodServer.Entities;

namespace FroodServer.Services;

public static class DtoMapper
{
    public static SpaceDto ToDto(Space space)
    {
        return new SpaceDto
        {
            Id = space.Id,
            Name = space.Name,
            Partners = space.Partners.Select(ToDto).ToList(),
        };
    }

    public static List<PartnerDto> ToDto(IEnumerable<Partner> partners)
    {
        return partners.Select(ToDto).ToList();
    }

    public static PartnerDto ToDto(Partner partner)
    {
        return new PartnerDto
        {
            Id = partner.Id,
            Name = partner.Name,
            MoodReport = ToDto(partner.MoodReport)
        };
    }

    public static MoodReportDto ToDto(MoodReport moodReport)
    {
        return new MoodReportDto
        {
            GlobalMood = moodReport.GlobalMood,
            UpdatedAt = moodReport.UpdatedAt,
            MoodCategories = moodReport.MoodCategories.Select(ToDto).ToList()
        };
    }

    public static MoodCategoryDto ToDto(MoodCategory moodCategory)
    {
        return new MoodCategoryDto
        {
            Id = moodCategory.Id,
            Name = moodCategory.Name,
            MoodTopics = moodCategory.MoodTopics.Select(ToDto).ToList()
        };
    }

    public static MoodTopicDto ToDto(MoodTopic moodTopic)
    {
        return new MoodTopicDto
        {
            Id = moodTopic.Id,
            Name = moodTopic.Name,
            Value = moodTopic.Value
        };
    }
}
