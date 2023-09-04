using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple_Banana.Interfaces
{
    public interface IVerseProcessor
    {
        char getVowel();
        bool IsVowel(string vowel);
        string processVerse(string Verse, char vowel);

    }
}
