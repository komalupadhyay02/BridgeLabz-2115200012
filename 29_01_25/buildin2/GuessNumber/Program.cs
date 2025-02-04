using System;

class NumberGuessingGame
{
    static void Main()
    {
        Console.WriteLine("Think of a number between 1 and 100.");
        Console.WriteLine("I will try to guess it!");
        
        int low = 1, high = 100;
        bool guessedCorrectly = false;

        while (!guessedCorrectly)
        {
            int guess = GenerateGuess(low, high);
            Console.WriteLine($"Is your number {guess}? (Enter 'h' for too high, 'l' for too low, 'c' for correct)");
            char feedback = GetUserFeedback();

            if (feedback == 'c')
            {
                Console.WriteLine($"Yay! I guessed your number {guess} correctly!");
                guessedCorrectly = true;
            }
            else if (feedback == 'h')
            {
                high = guess - 1;
            }
            else if (feedback == 'l')
            {
                low = guess + 1;
            }
        }
    }

    static int GenerateGuess(int low, int high)
    {
        Random random = new Random();
        return random.Next(low, high + 1);
    }

    static char GetUserFeedback()
    {
        char feedback;
        do
        {
            feedback = Console.ReadKey().KeyChar;
            Console.WriteLine();
        } while (feedback != 'h' && feedback != 'l' && feedback != 'c');
        
        return feedback;
    }
}
