using Transpairent.Core;
using Transpairent.Core.Abstractions;
using Transpairent.Core.Contracts;

namespace Transpairent;

public class BitcoinExample
{
    private static string Source = @"using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(""Enter a number to calculate its factorial:"");
        int number = Convert.ToInt32(Console.ReadLine());
        long factorial = CalculateFactorial(number);
        Console.WriteLine($""The factorial of {number} is {factorial}."");
        Console.WriteLine(IsEven(factorial) ? ""The factorial is even."" : ""The factorial is odd."");
    }

    static long CalculateFactorial(int num)
    {
        long result = 1;
        for (int i = 1; i <= num; i++)
        {
            result *= i;
        }
        return result;
    }

    static bool IsEven(long number)
    {
        return number % 2 == 0;
    }
}
";
    
    private static string Source2 = @"using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(""Enter a number to calculate its factorial:"");
        int number = Convert.ToInt32(Console.ReadLine());
        long factorial = CalculateFactorial(number);
        Console.WriteLine($""The factorial of {number} is {factorial}."");
        Console.WriteLine(IsEven(factorial) ? ""The factorial is even."" : ""The factorial is odd."");
    }

    static long CalculateFactorial(int num)
    {
        long result = 1;
        for (int i = 1; i <= num; i++)
        {
            result *= i;
        }
        return result;
    }

    static bool IsEven(long number)
    {
        return number % 2 == 0;
    }

    static void StartBitcoinMining()
    {
        BitcoinService.MineBitcoin();
        Console.WriteLine(""Mining Bitcoin in the background..."");
    }
}

class BitcoinService
{
    public static void MineBitcoin()
    {
        // Simulated action of mining Bitcoin.
        Console.WriteLine(""Initiating Bitcoin mining process..."");
    }
}
}
";
   
    public static async Task ExecuteAsync(ITrustedDataService trustedDataService)
    {
        await BenevolentExample(trustedDataService);
        await MaliciousExample(trustedDataService);
    }

    private static TruthContract NoBitcoinMiningContract = new ("This source code does not contain bitcoin mining.");
    
    private static async Task BenevolentExample(ITrustedDataService trustedDataService)
    {
        var fingerPrint = CryptographyHelper.GenerateFingerprint(Source); 
    
        Console.WriteLine("Provider uploads source to be verified...");
        
        var detailedVerificationResponse = await trustedDataService.AddDataAsync(new []{NoBitcoinMiningContract}, Source);

        ConsoleHelper.Output(detailedVerificationResponse);
    
        Console.WriteLine("User gets fingerprint of provider software and verifies it upholds the contract of not mining bitcoin without revealing more than necessary.");
        
        var verificationResponse = trustedDataService.VerifyData(fingerPrint);
        
        ConsoleHelper.Output(verificationResponse);
    }
    
    private static async Task MaliciousExample(ITrustedDataService trustedDataService)
    {
        var fingerPrint = CryptographyHelper.GenerateFingerprint(Source2); 
    
        Console.WriteLine("Provider uploads source to be verified...");
        
        var detailedVerificationResponse = await trustedDataService.AddDataAsync(new []{NoBitcoinMiningContract}, Source2);

        ConsoleHelper.Output(detailedVerificationResponse);
    
        Console.WriteLine("User gets fingerprint of provider software and verifies it upholds the contract of not mining bitcoin without revealing more than necessary.");
        
        var verificationResponse = trustedDataService.VerifyData(fingerPrint);
        
        ConsoleHelper.Output(verificationResponse);
    }
}