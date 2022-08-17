using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

/*
Palindrome Challenge :
As mentioned in the code test this challenge is to make a methode 
to recognize both alphabetical and numeric Palinfromes, ignoring 
all non alfanumeric characters, including whitespaces and casings.

To complete this challange I've created a new class called Palindrome
to contain the methodes needed to seperate them from the main code for 
readablility and made several of the helper functions private to make
the methode easier to use.
*/


namespace Code_Test
{
    class Palindrome
    {
        /*
        To remove whitespace and special characters we use a regex expression
        that matches with all non alfanumerical characters (including danish) 
        and replace them with nothing.
        afterward we use the ToLower methode form String 
        to make all characters lower case.
        */
        private string reduceWord(string word)
        {
            word = Regex.Replace(word, "([^A-z^0-9æøåÆØÅ])", "");
            word = word.ToLower();

            return word;
        }

        /*
        A string is reversed by iterating backwards over the string one character at a time,
        and concatenade each to a new string reversedWord
        Word index is reduced by one from word.Lenght to match with the string index
        */
        private string reverseWord(string word)
        {
            string reverseWord = "";
            int wordIndex = word.Length-1;
            for (int i = wordIndex; i >= 0; i--)
            {
                reverseWord += word[i];
            }
            return reverseWord;
        }

        /*
        converting the int to a string is an easy solution, as we already have a way to reverse string
        */
        private int reverseInt(int i)
        {
            string s = i.ToString();
            s = reverseWord(s);
            i = Convert.ToInt32(s);
            return i;
        }
        
        /*
        Having seperated the functionallity into helper methodes has made the public methode
        very simple and readable, now we can simple reduce the words and make a reversed copy
        and finally use the string methode Equals to check if both are the same 
        then return the resulting bool 
        */
        public bool checkIfPalindrome(string word)
        {
            try
            {
                word = reduceWord(word);
                string wordReversed = reverseWord(word);
                return word.Equals(wordReversed);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        /*
        Same as above, only here we need to remove the sign.
        */
        public bool checkIfPalindrome(int interger)
        {
            try
            {
                interger = Math.Abs(interger);
                int intergerReversed = reverseInt(interger);
                return (interger == intergerReversed);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
