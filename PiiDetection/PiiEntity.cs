namespace PiiDetection;

/// <summary>
/// Represents a detected Personally Identifiable Information (PII) entity in text
/// </summary>
public class PiiEntity
{
    /// <summary>
    /// The type of PII detected
    /// </summary>
    public PiiType Type { get; }
    
    /// <summary>
    /// The original value of the PII
    /// </summary>
    public string Text { get; }
    
    /// <summary>
    /// The starting position of the PII in the text
    /// </summary>
    public int Start { get; }
    
    /// <summary>
    /// The length of the PII in the text
    /// </summary>
    public int Length { get; }
    
    /// <summary>
    /// The confidence score of the detection
    /// </summary>
    public double Confidence { get; }

    /// <summary>
    /// Creates a new instance of PiiEntity
    /// </summary>
    /// <param name="type">The type of PII</param>
    /// <param name="text">The original value</param>
    /// <param name="start">The starting position</param>
    /// <param name="length">The length of the PII</param>
    /// <param name="confidence">The confidence score of the detection</param>
    public PiiEntity(PiiType type, string text, int start, int length, double confidence)
    {
        Type = type;
        Text = text;
        Start = start;
        Length = length;
        Confidence = confidence;
    }

    public override string ToString()
    {
        return $"{Type} ({Confidence:F2}): {Text} at position {Start}";
    }
} 