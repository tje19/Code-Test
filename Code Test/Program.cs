using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Code_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }
        static void Menu()
        {
            Palindrome palindrome = new Palindrome();
            Console.Write("Type 'word' if you wish to check a word-\nType 'number' if you wish to check a number.\n>>>");
            string input = Console.ReadLine();
            Console.Write("What do you want to check?\n>>>");
            string inputWord = Console.ReadLine();
            try
            {
                if (input.Equals("number")) { Convert.ToInt32(inputWord); }
                bool result = palindrome.checkIfPalindrome(inputWord);
                if (result) 
                { Console.WriteLine(inputWord + " is a palindrome\n"); }
                else if (result is false) 
                { Console.WriteLine(inputWord + "is not a palindrome\n"); }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error Log: Argument Exception\n");
            }
            catch (Exception)
            {
                Console.WriteLine("Error Log: Exception\n");
            }

        }
    }


}