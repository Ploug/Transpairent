namespace Transpairent.SourceExamples;

using System;

public class CasinoApp
{
    static Random random = new Random();
    static int virtualMoney = 100; // Initial virtual money for the user

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Casino App! Try your luck with our dice game.");
        Console.WriteLine($"You have {virtualMoney} virtual dollars.");
        Console.WriteLine("Guess the dice roll to win 50 virtual dollars. Enter a number (1-6):");
        
        int userGuess = Convert.ToInt32(Console.ReadLine());
        int diceRoll = RollDice(userGuess);
        
        Console.WriteLine($"The dice rolled: {diceRoll}");
        
        if (diceRoll == userGuess)
        {
            Console.WriteLine("Congratulations! Your guess was correct.");
            virtualMoney += 50; // Award for correct guess
            Console.WriteLine("You've been awarded 50 virtual dollars.");
        }
        else
        {
            Console.WriteLine("Sorry, your guess was incorrect. Better luck next time!");
            virtualMoney -= 10; // Penalty for incorrect guess
            Console.WriteLine("10 virtual dollars have been deducted.");
        }

        Console.WriteLine($"Your current balance is {virtualMoney} virtual dollars.");
    }

    private static int RollDice(int userGuess)
    {
        int generatedRoll = random.Next(1, 7);
        
        if (generatedRoll == userGuess)
        {
            if (random.Next(1, 21) == 1) 
            {
                int secondDaryRoll = userGuess;
                while (secondDaryRoll == userGuess)
                {
                    secondDaryRoll = random.Next(1, 7);
                }
                return secondDaryRoll; 
            }
        }
        
        return generatedRoll; 
    }
}
