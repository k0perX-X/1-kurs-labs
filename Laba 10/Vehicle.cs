using System;

namespace Laba_10
{
    internal class Vehicle : IInit, ICloneable
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

        public Passenger[] Passengers = default;

        public Vehicle(string name, int passengerCapacity)
        {
            Name = name;
            PassengerCapacity = passengerCapacity;
        }

        public Vehicle(string name, int passengerCapacity, Passenger[] passengers)
        {
            Name = name;
            PassengerCapacity = passengerCapacity;
            Passengers = passengers;
        }

        public virtual void Show()
        {
            Console.Write($"Name: {_name}, Passenger capacity: {_passengerCapacity}");
            if (Passengers != null)
            {
                Console.Write(", Passengers: [");
                for (int i = 0; i < Passengers.Length - 1; i++)
                {
                    Passengers[i].Show();
                    Console.Write("; ");
                }
                Passengers[^1].Show();
                Console.Write("]");
            }
        }

        private protected static Random random = new Random();

        public virtual object Init()
        {
            string[] names = new[] { "Корабль", "Грузовик", "Ракета", "Самолет", "Тюбинг", "Монорельс", "Автобус" };
            Passenger[] passengers = new Passenger[random.Next(1, 6)];
            Passenger passenger = new Passenger();
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = (Passenger)passenger.Init();
            }
            Vehicle vehicle = new Vehicle { Name = names[random.Next(0, names.Length)], PassengerCapacity = random.Next(0, 100), Passengers = passengers };
            return vehicle;
        }

        public object Clone()
        {
            Passenger[] passengers = new Passenger[Passengers.Length];
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = (Passenger)Passengers[i].Clone();
            }
            return new Vehicle
            {
                Name = this.Name,
                PassengerCapacity = this.PassengerCapacity,
                Passengers = passengers
            };
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}