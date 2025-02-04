using System;

class ReverseString
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the String:");
        string input = Console.ReadLine();
        
        bool IsPalindrome = CheckPalindrome(input);
        Console.WriteLine($"Is the String a Palindrome? {IsPalindrome}");
    }

    static bool CheckPalindrome(string input)
    {
        int left = 0, right = input.Length - 1;
        
        while (left < right)
        {
            if (input[left] != input[right]) 
            {
                return false;
            }

            left++;
            right--;
        }
        return true;
    }
}
