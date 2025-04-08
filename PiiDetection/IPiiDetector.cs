namespace PiiDetection;

/// <summary>
/// Interface for detecting and masking Personally Identifiable Information (PII) in text
/// </summary>
public interface IPiiDetector
{
    /// <summary>
    /// Detects PII in the given text
    /// </summary>
    /// <param name="text">The text to analyze</param>
    /// <returns>A list of detected PII entities</returns>
    IEnumerable<PiiEntity> DetectPii(string text);

    /// <summary>
    /// Masks PII in the given text by replacing it with asterisks
    /// </summary>
    /// <param name="text">The text to mask</param>
    /// <returns>The text with PII masked</returns>
    string MaskPii(string text);
} 