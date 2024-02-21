using Transpairent.Core;
using Transpairent.Core.Abstractions;
using Transpairent.Core.Contracts;

namespace Transpairent;

public class CasinoAppExample
{
    private static string BenevolentCasinoAppSourcePath = "../../../SourceExamples/BenevolentCasinoApp.cs"; 
    private static string MaliciousCasinoAppSource = "../../../SourceExamples/MaliciousCasinoApp.cs"; 

    public static async Task ExecuteAsync(ITrustedDataService trustedDataService)
    {
        Console.WriteLine("Testing fair example...");
        await FairExample(trustedDataService);
        
        Console.WriteLine("Testing malicious example...");
        await MaliciousExample(trustedDataService);
    }
    
    private static BenevolentSoftwareContract CasinoAppContract = new ("To provide a fair casino app with virtual rewards. The dice rolls are not rigged and there is no tampering with the results of the 1-6 die.", "Do not sell my data");

    private static async Task FairExample(ITrustedDataService trustedDataService)
    {
        var benevolentSource = await ConsoleHelper.LoadSourceCodeAsync(BenevolentCasinoAppSourcePath);

        var fingerPrint = CryptographyHelper.GenerateFingerprint(benevolentSource); 
    
        Console.WriteLine("Provider uploads source to be verified...");
        
        var detailedVerificationResponse = await trustedDataService.AddDataAsync(new []{CasinoAppContract}, benevolentSource);

        ConsoleHelper.Output(detailedVerificationResponse);
    
        Console.WriteLine("User gets fingerprint of provider software and verifies it upholds the contract of not mining bitcoin without revealing more than necessary.");
        
        var verificationResponse = trustedDataService.VerifyData(fingerPrint);
        
        ConsoleHelper.Output(verificationResponse);
    }

    private static async Task MaliciousExample(ITrustedDataService trustedDataService)
    {
        var malicousSource = await ConsoleHelper.LoadSourceCodeAsync(MaliciousCasinoAppSource);
        
        var fingerPrint = CryptographyHelper.GenerateFingerprint(malicousSource); 
    
        Console.WriteLine("Provider uploads source to be verified...");
        
        var detailedVerificationResponse = await trustedDataService.AddDataAsync(new []{CasinoAppContract}, malicousSource);

        Console.WriteLine("Provider receives following response:");
        ConsoleHelper.Output(detailedVerificationResponse);
    
        Console.WriteLine("User gets fingerprint of provider software and verifies it upholds the contract of not mining bitcoin without revealing more than necessary.");
        
        var verificationResponse = trustedDataService.VerifyData(fingerPrint);
        
        Console.WriteLine("User receives following response:");
        ConsoleHelper.Output(verificationResponse);
    }
}