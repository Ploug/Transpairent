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
        Console.WriteLine();
    }
    
    public static async Task<string> LoadSourceCodeAsync(string filePath)
    {
        try
        {
            string sourceCode = await File.ReadAllTextAsync(filePath);
            return sourceCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            return string.Empty;
        }
    }
    
    public static void Output(VerificationResponse verificationResponse)
    {
        Console.WriteLine(verificationResponse.Success);

        foreach (var verification in verificationResponse.RequirementVerifications)
        {
            Console.WriteLine($"{verification.ContractRequirement.Title}: {verification.VerificationStatus}");
        }

        Console.WriteLine();
    }
}