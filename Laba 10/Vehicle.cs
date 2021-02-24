using System;

namespace Laba_10
{
    internal class Vehicle
    {
        private int _passengerCapacity;
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int PassengerCapacity
        {
            get => _passengerCapacity;
            set => _passengerCapacity = value;
        }

        public Vehicle()
        {
            Name = default;
            PassengerCapacity = 0;
        }

        public Vehicle(string name, int passengerCapacity)
        {
            Name = name;
            PassengerCapacity = passengerCapacity;
        }

        public virtual void Show()
        {
            Console.Write($"Name: {_name}, Passenger capacity: {_passengerCapacity}");
        }
    }
}