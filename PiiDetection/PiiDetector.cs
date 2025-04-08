using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace PiiDetection;

/// <summary>
/// Detects and masks Personally Identifiable Information (PII) in text using regex patterns
/// </summary>
public class PiiDetector : IPiiDetector
{
    private readonly ILogger<PiiDetector>? _logger;

    /// <summary>
    /// Creates a new instance of PiiDetector
    /// </summary>
    /// <param name="logger">Optional logger for debugging and monitoring</param>
    public PiiDetector(ILogger<PiiDetector>? logger = null)
    {
        _logger = logger;
    }

    /// <summary>
    /// Detects PII in the given text using regex patterns
    /// </summary>
    /// <param name="text">The text to analyze</param>
    /// <returns>A list of detected PII entities</returns>
    public IEnumerable<PiiEntity> DetectPii(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return Enumerable.Empty<PiiEntity>();
        }

        var entities = new List<PiiEntity>();
        _logger?.LogDebug("Analyzing text: {Text}", text);

        // Check with regex patterns
        foreach (var pattern in PiiPatterns.Patterns)
        {
            var matches = pattern.Value.Matches(text);
            _logger?.LogDebug("Pattern {PatternType}: Found {MatchCount} matches with pattern {Pattern}", 
                pattern.Key, matches.Count, pattern.Value.ToString());
            
            foreach (Match match in matches)
            {
                _logger?.LogDebug("Match found: {MatchText} at position {MatchIndex} with length {MatchLength}", 
                    match.Value, match.Index, match.Length);
                
                // For card numbers, validate with Luhn algorithm
                if (pattern.Key == PiiType.CardNumber && !IsValidLuhn(match.Value.Replace(" ", "").Replace("-", "")))
                {
                    _logger?.LogDebug("Card number {CardNumber} failed Luhn validation", match.Value);
                    continue;
                }

                // For IP addresses, validate each octet
                if (pattern.Key == PiiType.IPAddress && !IsValidIpAddress(match.Value))
                {
                    _logger?.LogDebug("IP address {IPAddress} failed validation", match.Value);
                    continue;
                }

                entities.Add(new PiiEntity(
                    pattern.Key,
                    match.Value,
                    match.Index,
                    match.Length,
                    1.0f // High confidence for regex matches
                ));
            }
        }

        _logger?.LogDebug("Found {EntityCount} PII entities", entities.Count);
        return entities;
    }

    /// <summary>
    /// Masks PII in the given text by replacing it with asterisks
    /// </summary>
    /// <param name="text">The text to mask</param>
    /// <returns>The text with PII masked</returns>
    public string MaskPii(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        var entities = DetectPii(text).OrderByDescending(e => e.Start).ToList();
        var result = text;

        foreach (var entity in entities)
        {
            var mask = new string('*', entity.Length);
            result = result.Remove(entity.Start, entity.Length)
                         .Insert(entity.Start, mask);
        }

        return result;
    }

    /// <summary>
    /// Validates a credit card number using the Luhn algorithm
    /// </summary>
    /// <param name="number">The card number to validate</param>
    /// <returns>True if the card number is valid according to the Luhn algorithm</returns>
    private static bool IsValidLuhn(string number)
    {
        if (string.IsNullOrEmpty(number) || number.Length < 13 || number.Length > 19)
        {
            return false;
        }

        int sum = 0;
        bool isEven = false;

        // Loop through values starting from the rightmost digit
        for (int i = number.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(number[i]))
                return false;

            int digit = number[i] - '0';

            if (isEven)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }

            sum += digit;
            isEven = !isEven;
        }

        return sum % 10 == 0;
    }

    /// <summary>
    /// Validates an IP address by checking each octet
    /// </summary>
    /// <param name="ipAddress">The IP address to validate</param>
    /// <returns>True if the IP address is valid</returns>
    private static bool IsValidIpAddress(string ipAddress)
    {
        if (string.IsNullOrEmpty(ipAddress))
        {
            return false;
        }

        string[] octets = ipAddress.Split('.');
        if (octets.Length != 4)
        {
            return false;
        }

        foreach (string octet in octets)
        {
            if (!int.TryParse(octet, out int value) || value < 0 || value > 255)
            {
                return false;
            }
        }

        return true;
    }
} 