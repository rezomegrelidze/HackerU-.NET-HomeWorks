using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CSharpScratchpad
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (Has2Digits(n))
            {
                var onesDigit = n % 10;
                var tenthsDigit = n / 10;
                Console.WriteLine($"in number {n} the {PrintWhichIsBigger(onesDigit,tenthsDigit)}");
            }
            else
            {
                Console.WriteLine($"n is not a 2 digit number");
            }
        }

        private static string PrintWhichIsBigger(int onesDigit, int tenthsDigit)
        {
            if (onesDigit == tenthsDigit) return $"{nameof(onesDigit)} and {nameof(tenthsDigit)} are equal";
            else if (onesDigit > tenthsDigit) return $"{nameof(onesDigit)} is greater than {nameof(tenthsDigit)}";
            else return $"{nameof(tenthsDigit)} is greater than {nameof(onesDigit)}";
        }

        private static bool Has2Digits(int n)
        {
            return InOpenInterval(n, 9, 100);
        }

        private static bool InOpenInterval(int n, int a, int b)
        {
            return n > a && n < b;
        }
    }
}


