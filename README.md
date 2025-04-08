# PII Detection Library

⚠️ **IMPORTANT NOTICE** ⚠️

This project is an experimental implementation created through "vibe programming" as a test/proof of concept. It should NOT be used in production environments and should be assumed non-functional. The code exists purely for educational and experimental purposes. For production PII detection, please use established and thoroughly tested solutions.

## Overview

PiiDetection is a C# library that demonstrates pattern-based detection of Personally Identifiable Information (PII) in text. It uses regular expressions to identify potential PII such as:

- Email addresses
- UK phone numbers
- UK postcodes
- National Insurance numbers
- NHS numbers
- UK passport numbers
- UK driving license numbers
- Bank account details
- Credit/debit card numbers (with Luhn algorithm validation)
- Dates of birth
- IP addresses

## Project Structure

```
PiiDetection/
├── PiiDetection/
│   ├── PiiDetector.cs        # Main detection logic
│   ├── PiiPatterns.cs        # Regular expression patterns
│   ├── PiiType.cs            # PII type enumeration
│   ├── PiiEntity.cs          # Entity model
│   ├── IPiiDetector.cs       # Interface definition
│   └── ServiceCollectionExtensions.cs  # DI setup
└── PiiDetection.Tests/
    ├── PiiDetectorTests.cs
    └── ServiceCollectionExtensionsTests.cs
```

## Usage Example

```csharp
// Create detector instance
var detector = new PiiDetector();

// Detect PII in text
string text = "My email is john.doe@example.com and my phone is 07700 900123";
var detectedPii = detector.Detect(text);

// Mask PII in text
string maskedText = detector.MaskPii(text);
// Result: "My email is ********************* and my phone is ***************"
```

## Dependency Injection

The library supports dependency injection through extension methods:

```csharp
services.AddPiiDetection();
```

Then inject `IPiiDetector` into your services:

```csharp
public class MyService
{
    private readonly IPiiDetector _piiDetector;

    public MyService(IPiiDetector piiDetector)
    {
        _piiDetector = piiDetector;
    }
}
```

## Limitations

- Uses simple pattern matching which may produce false positives/negatives
- No context awareness
- Limited to specific UK-format patterns
- No machine learning or advanced NLP techniques
- No validation against real-world databases
- No support for international formats
- Performance not optimized for large-scale processing

## Contributing

This is an experimental project and is not actively maintained. However, if you'd like to experiment with it:

1. Fork the repository
2. Create a feature branch
3. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Disclaimer

This code is provided "as is" without warranty of any kind. It is not intended for production use and should only be used for educational or experimental purposes. The patterns and detection methods used may be incomplete, inaccurate, or outdated.