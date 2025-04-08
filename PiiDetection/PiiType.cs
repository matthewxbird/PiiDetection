namespace PiiDetection;

/// <summary>
/// Represents different types of Personally Identifiable Information (PII)
/// </summary>
public enum PiiType
{
    Unknown,
    Person,
    Organization,
    Location,
    DateTime,
    Email,
    PhoneNumber,
    CreditCard,
    SSN,
    Address,
    IPAddress,
    URL,
    Password,
    Username,
    BankAccount,
    PassportNumber,
    DriverLicense,
    MedicalRecord,
    InsurancePolicy
} 