namespace FroodServer.Controllers.Requests;

public record CreateMoodTopicRequest(Guid MoodCategoryId, string MoodTopicName);
