using PiiDetection;

namespace PiiDetection.Api.Models;

public class PiiDetectionResponse
{
    public IEnumerable<PiiEntity> DetectedEntities { get; set; } = new List<PiiEntity>();
    public string MaskedText { get; set; } = string.Empty;
} 