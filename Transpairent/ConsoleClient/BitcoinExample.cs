using Transpairent.Core;
using Transpairent.Core.Abstractions;
using Transpairent.Core.Contracts;

namespace Transpairent;

public class BitcoinExample
{
    private static string BenevolentSourcePath = "../../../SourceExamples/BenevolentBitcoinApp.cs"; 
    private static string MalicousSourcePath = "../../../SourceExamples/MaliciousBitcoinApp.cs"; 
   
    public static async Task ExecuteAsync(ITrustedDataService trustedDataService)
    {
        Console.WriteLine("Testing benevolent example...");
        await BenevolentExample(trustedDataService);
        Console.WriteLine("Testing malicious example...");
        await MaliciousExample(trustedDataService);
    }

    private static TruthContract NoBitcoinMiningContract = new ("This source code does not contain bitcoin mining.");
    
    private static async Task BenevolentExample(ITrustedDataService trustedDataService)
    {
        var benevolentSource = await ConsoleHelper.LoadSourceCodeAsync(BenevolentSourcePath);
        
        var fingerPrint = CryptographyHelper.GenerateFingerprint(benevolentSource); 
    
        Console.WriteLine("Provider uploads source to be verified...");
        
        var detailedVerificationResponse = await trustedDataService.AddDataAsync(new []{NoBitcoinMiningContract}, benevolentSource);

        ConsoleHelper.Output(detailedVerificationResponse);
    
        Console.WriteLine("User gets fingerprint of provider software and verifies it upholds the contract of not mining bitcoin without revealing more than necessary.");
        
        var verificationResponse = trustedDataService.VerifyData(fingerPrint);
        
        ConsoleHelper.Output(verificationResponse);
    }
    
    private static async Task MaliciousExample(ITrustedDataService trustedDataService)
    {
        var malicousSource = await ConsoleHelper.LoadSourceCodeAsync(MalicousSourcePath);
        
        var fingerPrint = CryptographyHelper.GenerateFingerprint(malicousSource); 
    
        Console.WriteLine("Provider uploads source to be verified...");
        
        var detailedVerificationResponse = await trustedDataService.AddDataAsync(new []{NoBitcoinMiningContract}, malicousSource);

        Console.WriteLine("Provider receives following response:");
        ConsoleHelper.Output(detailedVerificationResponse);
    
        Console.WriteLine("User gets fingerprint of provider software and verifies it upholds the contract of not mining bitcoin without revealing more than necessary.");
        
        var verificationResponse = trustedDataService.VerifyData(fingerPrint);
        
        Console.WriteLine("User receives following response:");
        ConsoleHelper.Output(verificationResponse);
    }
}