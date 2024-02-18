using Transpairent.Core.Abstractions;

namespace Transpairent;

public static class ConsoleHelper
{
    public static void Output(VerificationDetailedResponse detailedVerificationResponse)
    {
        Console.WriteLine(detailedVerificationResponse.Success);
    
        foreach (var verification in detailedVerificationResponse.RequirementVerifications)
        {
            Console.WriteLine($"{verification.ContractRequirement.Title}: {verification.VerificationStatus} ({verification.Reason})");
        }
    }
    
    public static void Output(VerificationResponse verificationResponse)
    {
        Console.WriteLine(verificationResponse.Success);

        foreach (var verification in verificationResponse.RequirementVerifications)
        {
            Console.WriteLine($"{verification.ContractRequirement.Title}: {verification.VerificationStatus}");
        }
    }
}