using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeIsValidNumber
{
    public class Solution
    {
        public bool IsNumber(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            
            return (IsDecimal(s) || IsInteger(s));
            
        }

        private bool IsDecimal(in string s)
        {
            try
            {
                var idx = 0;
                OptionalSign(s, idx, out idx);
                OptionalSpaces(s, idx, out idx);
                var digitsForWholePart  = CountContiguousDigitsFrom(s, idx, out idx);
                AssertDecimalPoint(s, idx, out idx);
                var digitsForFracPart = CountContiguousDigitsFrom(s, idx, out idx);

                // Guard for string "." where no whole part or fract parts in number!
                if (digitsForWholePart == 0 && digitsForFracPart == 0)
                    return false;

                OptionalExponent(s, idx, out idx);
                AssertEndOfLine(s, idx);
                return true;
            }
            catch
            {
                return false;
            }
        }



        private bool IsInteger(in string s)
        {
            try
            {
                var idx = 0;
                OptionalSign(s, idx, out idx);
                OptionalSpaces(s, idx, out idx);
                var digitsForWholePart = CountContiguousDigitsFrom(s, idx, out idx);

                // have we been given an integer with no digits whatsoever?
                if (digitsForWholePart == 0)
                    return false;

                OptionalExponent(s, idx, out idx);
                AssertEndOfLine(s, idx);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private static void OptionalSpaces(in string s, in int idx, out int newIdx)
        {
            newIdx = idx;

            char ch = s[newIdx];
            while (char.IsWhiteSpace(ch) & newIdx < s.Length)
            {
                newIdx++;
                ch = s[newIdx];
            }
        }


        private static void OptionalSign(in string s, in int idx, out int newIdx)
        {
            newIdx = idx;

            char ch = s[newIdx];
            if (ch == '-' || ch == '+')
                newIdx ++;
        }

        

        private static void OptionalExponent(in string s, in int idx, out int newIdx)
        {
            newIdx = idx;

            if (idx>= s.Length)
                return;
            
            char ch = s[newIdx];
            if (ch != 'e' && ch != 'E')
                return;

            newIdx++;

            if (newIdx >= s.Length)
                throw new ArgumentException("Expected +, - or digit");

            ch = s[newIdx];
            if (ch == '+' || ch == '-')
                newIdx++;

            bool haveAtLeastOneDigit = CountContiguousDigitsFrom(s, newIdx, out newIdx) > 0;

            if (!haveAtLeastOneDigit)
                throw new ArgumentException("At least one digit must be supplied for exponent.");
        }

        private static int CountContiguousDigitsFrom(in string s, in int idx, out int newIdx)
        {
            newIdx = idx;

            if (idx >= s.Length)
                return 0;

            int countOfDigits = 0;

            char ch = s[newIdx];
            while (char.IsDigit(ch))
            {
                countOfDigits++;

                if (++newIdx == s.Length)
                    break;

                ch = s[newIdx];
            }

            return countOfDigits;
        }


        private static void AssertDecimalPoint(in string s, in int idx, out int newIdx)
        {
            newIdx = idx;
            char ch = s[idx];
            if (ch != '.')
                throw new ArgumentException("expected dot");

            newIdx++;
        }

        private static void AssertEndOfLine(in string s, in int idx)
        {
            if (idx < s.Length)
                throw new ArgumentException($"Have not reached end of line in {s} at position {idx}");
        }


    }
}
