namespace FroodServer.Controllers.Requests;

public record CreateMoodCategoryRequest(Guid PartnerId, string MoodCategoryName);
