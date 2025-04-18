using System.Linq;
using Xunit;
using PiiDetection;

namespace PiiDetection.Tests;

public class PiiDetectorTests
{
    private readonly IPiiDetector _detector;

    public PiiDetectorTests()
    {
        _detector = new PiiDetector();
    }

    [Theory]
    [InlineData("test@example.com", "****************")]
    [InlineData("my.email@domain.co.uk", "*********************")]
    [InlineData("no pii here", "no pii here")]
    public void MaskPii_WithEmail_ShouldMaskCorrectly(string input, string expected)
    {
        var result = _detector.MaskPii(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("+44 7911 123456", "***************")]
    [InlineData("020 7123 4567", "*************")]
    [InlineData("no phone here", "no phone here")]
    public void MaskPii_WithPhoneNumber_ShouldMaskCorrectly(string input, string expected)
    {
        var result = _detector.MaskPii(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("SW1A 1AA", "********")]
    [InlineData("EC1A 1BB", "********")]
    [InlineData("no postcode here", "no postcode here")]
    public void MaskPii_WithPostcode_ShouldMaskCorrectly(string input, string expected)
    {
        var result = _detector.MaskPii(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("AB123456C", "*********")]
    [InlineData("no NI number here", "no NI number here")]
    public void MaskPii_WithNationalInsuranceNumber_ShouldMaskCorrectly(string input, string expected)
    {
        var result = _detector.MaskPii(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123 456 7890", "************")]
    [InlineData("no NHS number here", "no NHS number here")]
    public void MaskPii_WithNhsNumber_ShouldMaskCorrectly(string input, string expected)
    {
        var result = _detector.MaskPii(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123456789", "*********")]
    [InlineData("no passport number here", "no passport number here")]
    public void MaskPii_WithPassportNumber_ShouldMaskCorrectly(string input, string expected)
    {
        var result = _detector.MaskPii(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ABCDE123456FGHIJ", "****************")]
    [InlineData("no driving license here", "no driving license here")]
    public void MaskPii_WithDrivingLicense_ShouldMaskCorrectly(string input, string expected)
    {
        var result = _detector.MaskPii(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("12-34-56-12345678", "*****************")]
    [InlineData("no bank details here", "no bank details here")]
    public void MaskPii_WithBankDetails_ShouldMaskCorrectly(string input, string expected)
    {
        var result = _detector.MaskPii(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("4532015112830366", "****************")]
    [InlineData("4532 0151 1283 0366", "*******************")]
    [InlineData("5425233430109903", "****************")]
    [InlineData("5425-2334-3010-9903", "*******************")]
    [InlineData("4012888888881881", "****************")]
    [InlineData("1234567812345678", "1234567812345678")]
    [InlineData("no card number here", "no card number here")]
    public void MaskPii_WithCardNumber_ShouldMaskCorrectly(string input, string expected)
    {
        var result = _detector.MaskPii(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaskPii_WithMultiplePii_ShouldMaskAllCorrectly()
    {
        var input = "Contact John at john@example.com or +44 7911 123456. Address: SW1A 1AA";
        var expected = "Contact John at **************** or ***************. Address: ********";
        var result = _detector.MaskPii(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void DetectPii_ShouldReturnCorrectEntities()
    {
        var input = "Email: test@example.com, Phone: +44 7911 123456";
        var entities = _detector.DetectPii(input).ToList();

        Console.WriteLine($"Found {entities.Count} entities:");
        foreach (var entity in entities)
        {
            Console.WriteLine($"Type: {entity.Type}, Text: {entity.Text}, Start: {entity.Start}, Length: {entity.Length}");
        }

        Assert.Equal(2, entities.Count);
        Assert.Contains(entities, e => e.Type == PiiType.Email && e.Text == "test@example.com");
        Assert.Contains(entities, e => e.Type == PiiType.PhoneNumber && e.Text == "+44 7911 123456");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void MaskPii_WithEmptyInput_ShouldReturnInput(string input)
    {
        var result = _detector.MaskPii(input);
        Assert.Equal(input, result);
    }

    [Fact]
    public void DetectPii_WithCardNumber_ShouldDetectValidCards()
    {
        var input = "Valid cards: 4532015112830366 and 5425-2334-3010-9903, but not 1234567812345678";
        var entities = _detector.DetectPii(input).ToList();

        Assert.Equal(2, entities.Count);
        Assert.Contains(entities, e => e.Type == PiiType.CardNumber && e.Text == "4532015112830366");
        Assert.Contains(entities, e => e.Type == PiiType.CardNumber && e.Text == "5425-2334-3010-9903");
    }
} 