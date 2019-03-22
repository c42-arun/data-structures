using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Recursion
{
    // https://www.educative.io/collection/page/10370001/760001/1210001
    public class Palindrome
    {
        public bool IsPalindrome(string s)
        {
            s = s.ToLower();

            // base case #1
            if (s.Length <= 1)
                return true;

            // base case #2
            string firstLetter = s.Substring(0, 1);
            string lastLetter = s.Substring(s.Length - 1);

            if (firstLetter != lastLetter)
                return false;

            // recursive case
            string stringWithFirstAndLastLettersRemoved = s.Substring(1, s.Length - 2);
            return IsPalindrome(stringWithFirstAndLastLettersRemoved);
        }
    }
}
