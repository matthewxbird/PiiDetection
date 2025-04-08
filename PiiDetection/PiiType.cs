namespace PiiDetection;

/// <summary>
/// Represents different types of Personally Identifiable Information (PII)
/// </summary>
public enum PiiType
{
    /// <summary>Unknown PII type</summary>
    Unknown,
    /// <summary>Person name</summary>
    Person,
    /// <summary>Organization name</summary>
    Organization,
    /// <summary>Location information</summary>
    Location,
    /// <summary>Date and time information</summary>
    DateTime,
    /// <summary>Email address</summary>
    Email,
    /// <summary>Phone number</summary>
    PhoneNumber,
    /// <summary>Credit card number</summary>
    CreditCard,
    /// <summary>Social Security Number</summary>
    SSN,
    /// <summary>Physical address</summary>
    Address,
    /// <summary>IP address</summary>
    IPAddress,
    /// <summary>URL or web address</summary>
    URL,
    /// <summary>Password</summary>
    Password,
    /// <summary>Username</summary>
    Username,
    /// <summary>Bank account information</summary>
    BankAccount,
    /// <summary>Passport number</summary>
    PassportNumber,
    /// <summary>Driver's license number</summary>
    DriverLicense,
    /// <summary>Medical record information</summary>
    MedicalRecord,
    /// <summary>Insurance policy information</summary>
    InsurancePolicy,
    /// <summary>UK postcode</summary>
    Postcode,
    /// <summary>UK National Insurance Number</summary>
    NationalInsuranceNumber,
    /// <summary>UK NHS Number</summary>
    NhsNumber,
    /// <summary>UK Driving License Number</summary>
    DrivingLicenseNumber,
    /// <summary>Bank account and sort code details</summary>
    BankDetails,
    /// <summary>Credit or debit card number</summary>
    CardNumber,
    /// <summary>Date of birth</summary>
    DateOfBirth
} 