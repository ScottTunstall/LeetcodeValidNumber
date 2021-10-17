using System;
using System.Diagnostics;

namespace LeetCodeIsValidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Solution();
            // bool isValid = x.IsNumber("- 123.456e789");

            //Debug.Assert(!x.IsNumber("0e"));

            Debug.Assert(x.IsNumber("005047e+6"));


        }
    }
}
