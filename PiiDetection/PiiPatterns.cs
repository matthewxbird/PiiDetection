using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PiiDetection;

/// <summary>
/// Contains regex patterns for detecting different types of PII
/// </summary>
public static class PiiPatterns
{
    /// <summary>
    /// Dictionary mapping PII types to their corresponding regex patterns
    /// </summary>
    public static readonly Dictionary<PiiType, Regex> Patterns = new()
    {
        // UK Email pattern
        { PiiType.Email, new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b", RegexOptions.Compiled) },
        
        // UK Phone numbers (including mobile and landline)
        { PiiType.PhoneNumber, new Regex(@"(?<!\w)(?:\+44|0)\s?\d{2,4}\s?\d{3,4}\s?\d{3,4}(?!\w)", RegexOptions.Compiled | RegexOptions.IgnoreCase) },
        
        // UK Postcodes
        { PiiType.Postcode, new Regex(@"(?<!\w)[A-Z]{1,2}[0-9][A-Z0-9]? ?[0-9][A-Z]{2}(?!\w)", RegexOptions.Compiled | RegexOptions.IgnoreCase) },
        
        // National Insurance Number
        { PiiType.NationalInsuranceNumber, new Regex(@"\b[A-Z]{2}[0-9]{6}[A-Z]\b", RegexOptions.Compiled) },
        
        // NHS Number
        { PiiType.NhsNumber, new Regex(@"\b[0-9]{3}[ ]?[0-9]{3}[ ]?[0-9]{4}\b", RegexOptions.Compiled) },
        
        // UK Passport Number
        { PiiType.PassportNumber, new Regex(@"\b[0-9]{9}\b", RegexOptions.Compiled) },
        
        // UK Driving License Number
        { PiiType.DrivingLicenseNumber, new Regex(@"\b[A-Z]{5}[0-9]{6}[A-Z]{5}\b", RegexOptions.Compiled) },
        
        // Bank Account Number (sort code and account number)
        { PiiType.BankAccount, new Regex(@"(?<!\w)\d{2}[- ]?\d{2}[- ]?\d{2}[- ]?\d{8}(?!\w)", RegexOptions.Compiled) },

        // Credit/Debit Card Numbers (supports major card formats with optional spaces/dashes)
        { PiiType.CardNumber, new Regex(@"\b\d{4}([- ]?\d{4}){3}\b", RegexOptions.Compiled) },
        
        // Date of Birth (various formats)
        { PiiType.DateOfBirth, new Regex(@"\b\d{1,2}[-/]\d{1,2}[-/]\d{2,4}\b", RegexOptions.Compiled) },
        
        // IP Address
        { PiiType.IPAddress, new Regex(@"\b(?:\d{1,3}\.){3}\d{1,3}\b", RegexOptions.Compiled) }
    };
} 