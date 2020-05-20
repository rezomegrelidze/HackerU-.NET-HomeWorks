using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        #region Part A

        #region Targil1

        public static class Targil1
        {
            public static void Run(string[] args)
            {
                Console.WriteLine("Enter a number:");
                int x = Convert.ToInt32(Console.ReadLine());
                Power2(ref x);
                Console.WriteLine($"power 2 of your number is {x}");
            }
            private static void Power2(ref int i)
            {
                i = i * 2;
            }
        }



        #endregion

        #region Question2

        // Answer: Yes. setting a[0] = 1 from outer function changes the element of a in index 0. 

        #endregion

        #region Question3

        // Answer: No. Because in function update you set "a" as a new array which means that changing it
        // won't change the original array that "a" was referencing.

        #endregion

        #region Targil4

        public static class Targil4
        {
            public static void Run()
            {
                InitializeArrays(out int[] a, out int[] b);
                for (int i = 0; i < a.Length; i++)
                {
                    Console.WriteLine(i);
                }
                for (int i = 0; i < b.Length; i++)
                {
                    Console.WriteLine(b[i]);
                }

            }

            private static void InitializeArrays(out int[] a, out int[] b)
            {
                Random r = new Random();
                a = new int[10];
                b = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    a[i] = r.Next(101);
                    b[i] = r.Next(101);
                }
            }
        }
        #endregion

        #region Targil5

        public static class Targil5
        {

            public static void Run()
            {
                Console.WriteLine(AddNumbers(1, 2, 3));
                Console.WriteLine(AddNumbersInArray(new[] { 1, 2, 3 }));
            }


            static int AddNumbersInArray(int[] nums)
            {
                return nums.Sum();
            }

            static int AddNumbers(params int[] numbers)
            {
                return numbers.Sum();
            }
        }

        #endregion

        #region Targil6

        static class Targil6
        {
            private static int[] a;
            public static void Run()
            {
                a = new int[10];
                InitializeArrays();
                PrintArray();

            }

            private static void PrintArray()
            {
                for (int i = 0; i < a.Length; i++)
                {
                    Console.WriteLine(a[i]);
                }
            }
            private static void InitializeArrays()
            {
                Random r = new Random();
                a = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    a[i] = r.Next(101);
                }
            }
        }


        #endregion


        #endregion

    }
}
