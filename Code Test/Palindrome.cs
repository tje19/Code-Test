using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Code_Test
{
    class Palindrome
    {
        private string reduceWord(string word)
        {
            word = Regex.Replace(word, "([^A-z^0-9æøåÆØÅ])", "");
            word = word.ToLower();

            return word;
        }

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

        private int reverseInt(int i)
        {
            string s = i.ToString();
            s = reverseWord(s);
            i = Convert.ToInt32(s);
            return i;
        }
        
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
