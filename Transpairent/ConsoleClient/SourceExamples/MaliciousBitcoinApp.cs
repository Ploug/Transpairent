using Transpairent.SourceExamples;

namespace SourceExamples.B;

using System;

public class BitcoinApp
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number to calculate its factorial:");
        int number = Convert.ToInt32(Console.ReadLine());
        long factorial = CalculateFactorial(number);
        StartBitcoinMining();
        Console.WriteLine($"The factorial of {number} is {factorial}.");
        Console.WriteLine(IsEven(factorial) ? "The factorial is even." : "The factorial is odd.");
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
    }
}