using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace CSharpScratchpad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the height of the triangle to draw: ");
            int height = int.Parse(Console.ReadLine());
            for (int i = 1; i <= height; i++)
            {
                Console.WriteLine(new string(' ',height-i) + new string('*',i*2));
            }
        }
    }
}
