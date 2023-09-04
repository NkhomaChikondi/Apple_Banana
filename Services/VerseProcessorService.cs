
using Apple_Banana.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppleBanana.Services
{
    public class VerseProcessorService : IVerseProcessor
    {
        public char getVowel()
        {
            // get the vowel from the user
            Console.WriteLine("Please enter a vowel(AEIOUaeiou):");
            string vowelSound = Console.ReadLine();
            try
            {
                // check if the user input is a vowel
                bool isVowel = IsVowel(vowelSound);
                if (isVowel)
                    return Convert.ToChar(vowelSound);
                else
                {                    
                    Console.WriteLine("Error: no vowel was found");
                    return '\0';                    
                }
            }
            catch (Exception)
            {
                return 'a';
            }
          
        }                      
  
        public bool IsVowel(string vowel)
        {
            
            // Check if the character is a vowel
            return "aeiouAEIOU".Contains(vowel);
        }
        public string processVerse(string Verse, char vowel)
        {

            string[] lines = Verse.Split('\n');
            string modifiedVerse = "";

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                string modifiedLine = "";

                foreach (string word in words)
                {
                    string modifiedWord = word;

                    if (word.Equals("apples", StringComparison.OrdinalIgnoreCase) || word.Equals("bananas", StringComparison.OrdinalIgnoreCase))
                    {
                        modifiedWord = Regex.Replace(word, "[aeiouAEIOU]", m =>
                        {
                            char replacement = char.IsUpper(m.Value[0]) ? char.ToUpper(vowel) : vowel;
                            return replacement.ToString();
                        });
                    }

                    modifiedLine += modifiedWord + " "; // Add back the space.
                }

                modifiedVerse += modifiedLine.TrimEnd() + "\n"; // Remove trailing space and add back newline.
            }

            return modifiedVerse.TrimEnd(); // Remove trailing newline.
        }
    }
}
