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
    class Program
    {
       
        static void Main(string[] args)
        {
            var bmwM3 = new Car() {_model = "BMW M3"};
            var kawasaki = new Motorcycle {_model = "Kawasaki COOL Moto"};
            var bmw745 = new Car() {_model = "BMW Black Bumer"};
            var bmwMoto = new Motorcycle() {_model = "BMW Super COOL MOTO"};

            var carrier = new Carrier() {Vehicles = new Vehicle[] {bmwM3, kawasaki, bmw745, bmwMoto}};
            Console.WriteLine(carrier);
        }
    }

    public class Carrier
    {
        public Vehicle[] Vehicles { get; set; }

        public override string ToString() => string.Join('\n', Vehicles.AsEnumerable());
    }

    public abstract class Vehicle
    {
        public int _numberOfWheels;
        public string _model;

        public abstract int GetMaxNumOfPassangers();
        public abstract int GetMaxSpeed();

        public override string ToString() => $"Model: {_model}, # of Wheels: {_numberOfWheels}, " +
                                             $"Max Passangers: {GetMaxNumOfPassangers()}, Max Speed: {GetMaxSpeed()}";
    }

    public class Car : Vehicle
    {
        public int _numberOfDoors;

        public Car()
        {
            _numberOfDoors = 4;
            _numberOfWheels = 4;
        }

        public override int GetMaxNumOfPassangers() => 5;

        public override int GetMaxSpeed() => 220;

        public override string ToString() => base.ToString() + $", # of Doors: {_numberOfDoors}";
    }

    public class Motorcycle : Vehicle
    {
        public int _numberOfHandBreaks;

        public Motorcycle()
        {
            _numberOfWheels = 2;
            _numberOfHandBreaks = 2;
        }

        public override int GetMaxNumOfPassangers() => 2;

        public override int GetMaxSpeed() => 250;

        public override string ToString() => base.ToString() + $", # of Handbreaks: {_numberOfHandBreaks}";
    }
}
