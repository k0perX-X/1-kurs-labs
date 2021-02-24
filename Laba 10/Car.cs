using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_10
{
    internal class Car : Vehicle
    {
        private int _numberOfDoors;

        public int NumberOfDoors
        {
            get => _numberOfDoors;
            set => _numberOfDoors = value;
        }

        public Car() : base()
        {
            NumberOfDoors = 0;
        }

        public Car(string name, int passengerCapacity, int numberOfDoors) : base(name, passengerCapacity)
        {
            NumberOfDoors = numberOfDoors;
        }

        public void Show()
        {
            base.Show();
            Console.Write($", Number of doors: {_numberOfDoors}");
        }
    }
}