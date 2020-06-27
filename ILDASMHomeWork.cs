using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*  Theoretical Questions:
     *
     *  Question 1: CIL is the intermediate language that every .NET based language is compiled to.
     *  When a given .NET app is executed the CIL code is compiled to the platform specific machine code. 
     *
     *  Question 2,3: ILDASM standes for IL disassembler. It can be used to inspect the code of .NET apps.
     *              There are also better applications for example .NET reflector which allows you to directly read C# code
     *              instead of having to understand CIL.
     *
     *  Question 4: Administrator, User, Guest. and one can add more types and roles.
     *
     *  Question 5: The command prompt is a command-line interface which allows users to input commands and get output
     *              in the command-line window. It's useful when a program doesn't have a guy or if you want to write
     *              batch files to automate some manual everyday tasks. Windows has a more powerful version of the command prompt
     *              namely Powershell and Powershell ISE which has intellisense. Also there's a new app called Windows Terminal
     *              Which contains cmd and powershell and azure cloud shell.
     *
     */

    class Program
    {
       
        /*
         *  Questions about IL.
         *
         *  Question: What IL instruction is used to call methods?
         *  Answer: The "call" instruction is used and any arguments are loaded on the call stack via ldarg instruction.
         *
         *
         */

        static void Main(string[] args)
        {
            var game1 = new Game(){CountryOfOrigin = "Georgia",Name = "Khachapuri eating",PlayerCount = 4,Rating = 5.4f};
            var game2 = new Game("sudoku"){CountryOfOrigin = "Japan",PlayerCount = 1,Rating = float.NegativeInfinity};
            var game3 = new Game("Chess",2,"Persia (don't really know haha)"){Rating = float.PositiveInfinity};
            var game4 = new Game("Taki","Israel"){PlayerCount = 4,Rating = 9};

            PrintGame(game4);
        }

        private static void PrintGame(Game game)
        {
            var number = game.TellMeHowManyPlayers();
            Console.WriteLine(game);
        }
    }

    public class Game
    {
        public string Name { get; set; }
        public int PlayerCount { get; set; }
        public float Rating { get; set; }
        public string CountryOfOrigin { get; set; }

        public Game()
        {
            
        }

        public Game(string name,float rating = 5.5f)
        {
            Name = name;
            Rating = rating;
        }

        public Game(string name,int playerCount,string countryOfOrigin)
        {
            Name = name;
            PlayerCount = playerCount;
            CountryOfOrigin = countryOfOrigin;
        }

        public Game(string name, string countryOfOrigin)
        {
            Name = name;
            CountryOfOrigin = countryOfOrigin;
        }

        public int TellMeHowManyPlayers() => PlayerCount;

    }
}
