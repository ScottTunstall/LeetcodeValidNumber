using System;

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

        private static bool IsDecimal(in string s)
        {
            var idx = 0;
            OptionalSign(s, idx, out idx);
            OptionalSpaces(s, idx, out idx);
            var digitsForWholePart = CountContiguousDigitsFrom(s, idx, out idx);

            if (!IsDecimalPoint(s, idx, out idx))
                return false;

            var digitsForFracPart = CountContiguousDigitsFrom(s, idx, out idx);

            // Guard for string "." where no whole part or fract parts in number!
            if (digitsForWholePart == 0 && digitsForFracPart == 0)
                return false;

            if (IsEndOfLine(s, idx))
                return true;

            if (!IsExponent(s, idx, out idx))
                return false;

            return IsEndOfLine(s, idx);
        }



        private static bool IsInteger(in string s)
        {
            var idx = 0;
            OptionalSign(s, idx, out idx);
            OptionalSpaces(s, idx, out idx);
            var digitsForWholePart = CountContiguousDigitsFrom(s, idx, out idx);

            // have we been given an integer with no digits whatsoever?
            if (digitsForWholePart == 0)
                return false;

            if (IsEndOfLine(s, idx))
                return true;

            if (!IsExponent(s, idx, out idx))
                return false;

            return IsEndOfLine(s, idx);
        }


        private static void OptionalSpaces(in string s,  int idx, out int newIdx)
        {
            newIdx = idx;

            if (IsEndOfLine(s, idx))
                return;

            char ch = s[newIdx];
            while (char.IsWhiteSpace(ch) & newIdx < s.Length)
            {
                newIdx++;
                ch = s[newIdx];
            }
        }


        private static void OptionalSign(in string s, int idx, out int newIdx)
        {
            newIdx = idx;

            if (IsEndOfLine(s, idx))
                return;

            char ch = s[idx];
            if (ch == '-' || ch == '+')
                newIdx++;
        }



        private static bool IsExponent(in string s, int idx, out int newIdx)
        {
            newIdx = idx;

            if (IsEndOfLine(s,idx))
                return false;

            char ch = s[idx];
            if (ch != 'e' && ch != 'E')
                return false;

            idx++;

            if (IsEndOfLine(s,idx))
                return false;

            ch = s[idx];
            if (ch == '+' || ch == '-')
                idx++;

            bool haveAtLeastOneDigit = CountContiguousDigitsFrom(s, idx, out idx) > 0;

            if (haveAtLeastOneDigit)
                newIdx = idx;

            return haveAtLeastOneDigit;
        }

        private static int CountContiguousDigitsFrom(in string s, in int idx, out int newIdx)
        {
            newIdx = idx;

            if (IsEndOfLine(s,idx))
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


        private static bool IsDecimalPoint(in string s, in int idx, out int newIdx)
        {
            newIdx = idx;

            if (IsEndOfLine(s,idx))
                return false;

            char ch = s[idx];
            if (ch != '.')
                return false;

            newIdx++;
            return true;
        }


        private static bool IsEndOfLine(in string s, in int idx)
        {
            return (idx == s.Length);
        }
    }
}
