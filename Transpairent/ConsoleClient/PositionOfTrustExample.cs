using Transpairent.Core;
using Transpairent.Core.Abstractions;
using Transpairent.Core.Contracts;

namespace Transpairent;

public class PositionOfTrustExample
{
     private static string BenevolentSourcePath = "../../SourceExamples/BenevolentPositionOfTrustLogs.txt"; 
    private static string MalicousSourcePath = "../../SourceExamples/MaliciousPositionOfTrustLogs.txt"; 
   
    public static async Task ExecuteAsync(ITrustedDataService trustedDataService)
    {
        Console.WriteLine("Testing benevolent example...");
        await BenevolentExample(trustedDataService);
        Console.WriteLine("Testing malicious example...");
        await MaliciousExample(trustedDataService);
    }
    public static TruthContract BriberyAndSelfBenefitContract = new TruthContract(
        "The individual acts in the best interest of the public/organization, without succumbing to bribery or personal gain.");
    
    private static async Task BenevolentExample(ITrustedDataService trustedDataService)
    {
        var benevolentSource = await ConsoleHelper.LoadSourceCodeAsync(BenevolentSourcePath);
        
        var fingerPrint = CryptographyHelper.GenerateFingerprint(benevolentSource); 
    
        Console.WriteLine("Bodycam and microphone data embedded on the person in position of trust in addition to phone logs gets uploaded to be verified...");
        
        var detailedVerificationResponse = await trustedDataService.AddDataAsync(new []{BriberyAndSelfBenefitContract}, benevolentSource);

        ConsoleHelper.Output(detailedVerificationResponse);
    
        Console.WriteLine("User gets fingerprint of provider software and verifies it upholds the contract of not mining bitcoin without revealing more than necessary.");
        
        var verificationResponse = trustedDataService.VerifyData(fingerPrint);
        
        ConsoleHelper.Output(verificationResponse);
    }
    
    private static async Task MaliciousExample(ITrustedDataService trustedDataService)
    {
        var malicousSource = await ConsoleHelper.LoadSourceCodeAsync(MalicousSourcePath);
        
        var fingerPrint = CryptographyHelper.GenerateFingerprint(malicousSource); 
        
        Console.WriteLine("Bodycam and microphone data embedded on the person in position of trust in addition to phone logs gets uploaded to be verified...");
        
        var detailedVerificationResponse = await trustedDataService.AddDataAsync(new []{BriberyAndSelfBenefitContract}, malicousSource);

        Console.WriteLine("Provider receives following response:");
        ConsoleHelper.Output(detailedVerificationResponse);
    
        Console.WriteLine("User gets fingerprint of provider software and verifies it upholds the contract of not mining bitcoin without revealing more than necessary.");
        
        var verificationResponse = trustedDataService.VerifyData(fingerPrint);
        
        Console.WriteLine("User receives following response:");
        ConsoleHelper.Output(verificationResponse);
    }
}