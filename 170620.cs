using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNETScratchpad
{
    /*      Question 1: What is object oriented programming?
     *      Answer: Object oriented programming is a style of programming where you focus on objects which can have
     *      have methods, properties and fields. Example of an object would be 'Person { Name, Age, sayHello() }' where
     *      Name and Age are properties and sayHello is a methods or an action that a person can perform. 
     *
     *      Question 2: What is a class, what is an instance?
     *      Answer: A class is a blueprint of an object. It defines the properties, methods and fields that an object has.
     *      An instance of a class is a particular object of given class with some values that can also be changed in the
     *      Lifetime of that object.
     *
     *      Question 3: How to create an object with C#?
     *      Answer: you can do it using the new Keyword (Although one can also use factory creation methods that a given
     *      class may contain). A typical example would be: var p = new Person { Name = "Raz", Age = 24 }; 
     *      Which uses object initializer syntactic sugar.
     *
     *      Question 4: Is C a OOP language, what about C++?
     *      Answer: C is not an OOP language. Although you can imitate objects with pointers and functions on that pointers.
     *      For example you can make a Stack with creating a Node struct and then creating functions like
     *      StackCreate() StackDestory() StackPush() StackPop() and you can pass the pointer of that instance of the stack
     *      as a pointer to every function that intern modifies the given node. Actually OOP objects work the probably the same
     *      exact way just the this pointer of an object is not needed to declared as an argument of every method. Altough
     *      In python it is the case that you should pass self to every method of a class.
     *      As for C++ it is a fully object oriented language.
     *
     *      Question 5: What is inheritance?
     *      Answer: It is the mechanism of basing an object on another object. And by this mechanism the object will
     *      get some of the behavior that the base object has. It is sometimes useful for code reuse. Although it's really
     *      abused most of the time. Building really long inheritance hierarchies can make the code hard to understand.
     *
     *      Question 6: What is an abstract class?
     *      Answer: An abstract class is a class which can't have it's own instance but can only be inherited by another class.
     *      It defines some abstract members which must be implemented by the derived class. You would typically use an
     *      interface for these purposes but an abstract class is sometimes needed if you want to defined some default static
     *      members and also other default behavior that all derived classes should have.
     *
     *      Question 7: What is ToString()?
     *      Answer: In C# every type is derived from System.Object. System.Object defines some virtual members that can be
     *      overriden by any given types. These are ToString(), GetHashCode() and Equals().
     *
     *      ToString() just returns a string representation of a given object and is used by methods such as
     *      Console.WriteLine().
     *
     *
     */


    [DebuggerDisplay("{model}, {price * 3.67}")]
    public class Computer
    { 
        private string model;
        private int price;
        private int numberOfProcessors;
        private float screenSize;
        private bool isTurnOn;

        public Computer(string model, int price, int numberOfProcessors, float screenSize, bool isTurnOn)
        {
            this.model = model;
            this.price = price;
            this.numberOfProcessors = numberOfProcessors;
            this.screenSize = screenSize;
            this.isTurnOn = isTurnOn;
        }

        public int TellMeThePrice() => price;
        public float TellMeTheScreenSize() => screenSize;
        public void TurnOff() => isTurnOn = false;
        public void TurnOn() => isTurnOn = true;
        public void AddProcessor() => numberOfProcessors++;

        public override string ToString()
        {
            return $"Model: {model}, Price: {price}, Processors: {numberOfProcessors}, Screen size: {screenSize}," +
                   $"Turned on: {isTurnOn}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var c = new Computer("HP Omen",1250,16,15.6f,true);
            Console.WriteLine(c);
        }
    }


    // this is some extra oop code i wrote for practice
    public class BackgammonGame
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Player CurrentPlayer { get; set; }

        public BackgammonGame()
        {
            Board = new Board();
            Player1 = new Player(PieceColor.White);
            Player2 = new Player(PieceColor.Black);
            CurrentPlayer = ChooseCurrentPlayer();
        }

        private Player ChooseCurrentPlayer()
        {
            var player1Die = Player1.RollDice().DieSum();
            var player2Die = Player2.RollDice().DieSum();

            if (player1Die > player2Die) return Player1;
            else if (player2Die > player1Die) return Player2;
            else return ChooseCurrentPlayer();
        }

        private void ChangePlayer()
        {
            CurrentPlayer = CurrentPlayer.Equals(Player1) ? Player2 : Player1;
        }

        public Board Board { get; set; }
    }

    public class Dice
    {
        static Random rand = new Random();
        /// <summary>
        /// Return dice result from 1 to 6 
        /// </summary>
        public static int RollDice => rand.Next(6) + 1;

        private Dice()
        {

        }
    }

    public class Board
    {
        public Board()
        {
            // first index will start from black's home board increasing counter clockwise
            // Description: 0-5 (black's home board), 6-11 (outer board),
            // 12-17 (outer board), 18-24 (white's home board
            //
            Triangles = new Triangle[24];

            PopulateTrianglesWithPieces();
        }

        private void PopulateTrianglesWithPieces()
        {
            PopulateBlackHomeBoard();
            PopulateFirstOuterBoard();
            PopulateSecondOuterBoard();
            PopulateWhiteHomeBoard();
        }

        private void PopulateWhiteHomeBoard()
        {
            var fiveWhitePieces = Enumerable.Repeat(Pieces.White, 5);
            Triangles[WhitesHomeBoardIndexes.first].AddPieces(fiveWhitePieces);

            var twoBlackPieces = Enumerable.Repeat(Pieces.Black, 2);
            Triangles[WhitesHomeBoardIndexes.last].AddPieces(twoBlackPieces);
        }

        private void PopulateSecondOuterBoard()
        {
            var fiveBlackPieces = Enumerable.Repeat(Pieces.Black, 5);
            Triangles[SecondOuterBoardIndexes.first].AddPieces(fiveBlackPieces);

            var threeWhitePieces = Enumerable.Repeat(Pieces.White, 3);
            Triangles[SecondOuterBoardIndexes.last-1].AddPieces(threeWhitePieces);
        }

        private void PopulateFirstOuterBoard()
        {
            var threeBlackPieces = Enumerable.Repeat(Pieces.Black, 3);
            // put three black pieces on second index of first outer board
            Triangles[FirstOuterBoardIndexes.first+1].AddPieces(threeBlackPieces);

            var fiveWhitePieces = Enumerable.Repeat(Pieces.White, 5);
            Triangles[FirstOuterBoardIndexes.last].AddPieces(fiveWhitePieces);
        }

        private void PopulateBlackHomeBoard()
        {
            var twoWhitePieces = Enumerable.Repeat(Pieces.White, 2);
            // put two white pieces in 0th index of blacks home board
            Triangles[BlackHomeBoardIndexes.first].AddPieces(twoWhitePieces); 
                

            var fiveBlackPieces = Enumerable.Repeat(Pieces.Black, 5);
            Triangles[BlackHomeBoardIndexes.last].AddPieces(fiveBlackPieces);
        }

        private (int first, int last) BlackHomeBoardIndexes => (0, 5);
        private (int first, int last) FirstOuterBoardIndexes => (6, 11);
        private (int first, int last) SecondOuterBoardIndexes => (12, 17);
        private (int first, int last) WhitesHomeBoardIndexes => (18, 24);

        public Triangle[] Triangles { get; set; }
    }

    public static class Pieces
    {
        public static Piece White => new Piece(PieceColor.White);
        public static Piece Black => new Piece(PieceColor.Black);
    }

    public class Triangle
    {
        public Triangle()
        {
            Pieces = new List<Piece>();   
        }

        public void AddPiece(Piece piece) => Pieces.Add(piece);
        public void AddPieces(IEnumerable<Piece> pieces) => Pieces.AddRange(pieces);

        public List<Piece> Pieces { get; set; }

        public int PieceCount => Pieces.Count;
    }

    public struct Piece
    {
        public Piece(PieceColor color) => Color = color;

        public PieceColor Color { get; set; }
    }

    public enum PieceColor
    {
        White, Black
    }

    public class Player
    {
        public Player(PieceColor color) => Color = color;
        public Direction Direction => Color == PieceColor.White ? Direction.CounterClockWise : Direction.ClockWise;
        public PieceColor Color { get; set; }
        public (int first, int second) RollDice() => (Dice.RollDice, Dice.RollDice);
    }

    public static class DiceExtensions
    {
        public static int DieSum(this (int, int) diceResult) => diceResult.Item1 + diceResult.Item2;
    }

    public enum Direction
    {
        CounterClockWise, ClockWise
    }
}
