using Microsoft.AspNetCore.Mvc;
using PiiDetection;
using PiiDetection.Api.Models;

namespace PiiDetection.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PiiDetectionController : ControllerBase
{
    private readonly IPiiDetector _piiDetector;
    private readonly ILogger<PiiDetectionController> _logger;

    public PiiDetectionController(IPiiDetector piiDetector, ILogger<PiiDetectionController> logger)
    {
        _piiDetector = piiDetector;
        _logger = logger;
    }

    [HttpPost("detect")]
    public IActionResult DetectPii([FromBody] PiiDetectionRequest request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.Text))
            {
                return BadRequest("Text cannot be empty");
            }

            var detectedEntities = _piiDetector.DetectPii(request.Text);
            var maskedText = _piiDetector.MaskPii(request.Text);

            var response = new PiiDetectionResponse
            {
                DetectedEntities = detectedEntities,
                MaskedText = maskedText
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error detecting PII in text");
            return StatusCode(500, "An error occurred while processing your request");
        }
    }
} 