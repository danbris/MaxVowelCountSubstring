using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VowelsSubstring
{
    public class VowelsCount
    {
        public static string FindSubstring(string s, int k)
        {
            var vowels = new [] { 'a', 'e', 'i', 'o', 'u' };
            var occurences = 0;
            var idx = -1;
            if (k <= 0 || !vowels.Any(s.Contains))
                return "Not found!";

            var previousCount = 0;
            for (var i = 0; i <= s.Length - k; i++)
            {
                if (i > 0)
                {
                    var oldChar = s[i - 1];
                    var newChar = s[i + k - 1];
                    var isOldVowel = vowels.Contains(oldChar);//avoid multiple func calls
                    var isNewVowel = vowels.Contains(newChar);

                    //so far the fastest solution
                    if (isOldVowel && isNewVowel || !isOldVowel && !isNewVowel)
                    {
                        //same count, one vowel exited and one entered
                        continue;
                    }
                    
                    if (isOldVowel)
                    {
                        previousCount--;
                        continue;
                    }

                    previousCount++;
                    if (previousCount <= occurences) continue;
                    idx = i;
                    occurences = previousCount;
                }
                else
                {
                    var noOfVowels = s.Substring(i, k).Count(x => vowels.Contains(x));
                    if (noOfVowels > occurences)
                    {
                        idx = i;
                        occurences = noOfVowels;
                    }

                    previousCount = noOfVowels;
                }
            }

            return s.Substring(idx, k);
        }
    }
}
