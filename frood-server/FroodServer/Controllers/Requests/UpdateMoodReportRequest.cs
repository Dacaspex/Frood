using FroodServer.Dtos.Request;

namespace FroodServer.Controllers.Requests;

public class UpdateMoodReportRequest
{
    public Guid PartnerId { get; set; }
    public MoodReportUpdateDto MoodReport { get; set; }
}
