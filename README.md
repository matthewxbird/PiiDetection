# 🎭 PiiDetection - The "It Works On My Machine" Edition

> ⚠️ **WARNING: This is an experimental project created through the mystical art of "vibe programming"** ⚠️
>
> If you're looking for production-ready code, you've wandered into the wrong repository. This is where we turn coffee into questionable code and hope for the best! 

## 🎭 The Vibe Programming Manifesto

```
In a world of clean code and best practices,
We chose chaos, we chose vibes.
No tests? No problem!
Documentation? That's for quitters!
We code by the seat of our pants,
And debug by the light of the moon.
When the compiler complains,
We simply vibe harder.
For in the end, if it works on my machine,
That's all that really matters, right?
```

## 🎪 What's This Madness?

Welcome to PiiDetection, where we detect Personally Identifiable Information (PII) using the power of vibes and questionable regex patterns! This library is like a fortune teller for your text - it might be right, it might be wrong, but it's always entertaining!

## 🎨 Features

- Detect PII using regex patterns that we're pretty sure about (mostly)
- Mask detected PII with asterisks (because privacy!)
- Support for various UK formats (we think)
- Dependency injection support (because we're fancy like that)
- Extensive logging (to help you understand why it's not working)

## 🎪 Usage

```csharp
// Add to your services
services.AddPiiDetection();

// Use it (at your own risk)
var detector = serviceProvider.GetRequiredService<IPiiDetector>();
var masked = detector.MaskPii("My email is test@example.com");
// Result: "My email is ****************"
// (Unless it doesn't work, then it's probably your fault)
```

## 🎭 Project Structure

```
PiiDetection/
├── PiiDetector.cs         # The main attraction
├── PiiPatterns.cs         # Our collection of questionable regex
├── PiiType.cs            # Because enums are fun
├── PiiEntity.cs          # For when we need to pretend we're professional
└── ServiceCollectionExtensions.cs  # Dependency injection magic
```

## 🎪 Limitations

- May or may not detect PII correctly
- Regex patterns are based on vibes and prayers
- No guarantee of accuracy (or functionality)
- May cause spontaneous debugging sessions
- Side effects may include: hair loss, coffee addiction, and existential crises

## 🤡 Contributing

Want to contribute? Great! Just follow these steps:

1. Fork the repository
2. Make your changes (the more chaotic, the better)
3. Submit a pull request
4. Cross your fingers
5. Hope for the best

## 📜 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## ⚠️ Disclaimer

This project is provided "as is" with no warranty, guarantee, or promise of functionality. Use at your own risk. We are not responsible for any data leaks, security breaches, or existential crises that may occur while using this library.

Remember: If it works, it's a feature. If it doesn't, it's a learning experience! 🎭