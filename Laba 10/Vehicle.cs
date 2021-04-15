using System;

namespace Laba_10
{
    public class Vehicle : IInit, ICloneable
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
            Passengers = default;
        }

        public Passenger[] Passengers = default;

        public Vehicle(string name, int passengerCapacity)
        {
            Name = name;
            PassengerCapacity = passengerCapacity;
            Passengers = default;
        }

        public Vehicle(string name, int passengerCapacity, Passenger[] passengers)
        {
            Name = name;
            PassengerCapacity = passengerCapacity;
            Passengers = passengers;
        }

        public virtual void Show()
        {
            Console.Write($"Name: {_name}, Passenger capacity: {_passengerCapacity}, Passengers: [");
            if (Passengers != null)
                if (Passengers.Length != 0)
                {
                    for (int i = 0; i < Passengers.Length - 2; i++)
                    {
                        Passengers[i].Show();
                        Console.Write("; ");
                    }
                    Passengers[^1].Show();
                }
            Console.Write("]");
        }

        private protected static Random random = new Random();

        public virtual object Init()
        {
            int passengerCapacity = random.Next(0, 100);
            string[] names = new[] { "Корабль", "Грузовик", "Ракета", "Самолет", "Тюбинг", "Монорельс", "Автобус" };
            Passenger[] passengers = new Passenger[random.Next(0, passengerCapacity + 1)];
            Passenger passenger = new Passenger();
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = (Passenger)passenger.Init();
            }
            Vehicle vehicle = new Vehicle { Name = names[random.Next(0, names.Length)], PassengerCapacity = passengerCapacity, Passengers = passengers };
            return vehicle;
        }

        public virtual object Clone()
        {
            if (Passengers != null)
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
            else
            {
                return new Vehicle
                {
                    Name = this.Name,
                    PassengerCapacity = this.PassengerCapacity,
                    Passengers = default
                };
            }
        }

        public override string ToString()
        {
            string s = $"Name: {_name}, Passenger capacity: {_passengerCapacity}, Passengers: [";
            if (Passengers != default)
                if (Passengers.Length > 0)
                {
                    for (int i = 0; i < Passengers.Length - 2; i++)
                    {
                        s += Passengers[i].ToString() + "; ";
                    }

                    s += Passengers[^1].ToString();
                }
            return s + "]";
        }

        public static bool operator ==(Vehicle v1, Vehicle v2)
        {
            if (v1.Passengers.Length != v2.Passengers.Length)
                return false;
            for (int i = 0; i < v1.Passengers.Length; i++)
            {
                if (v1.Passengers[i] != v2.Passengers[i])
                    return false;
            }
            if (v1.Name != v2.Name || v1.PassengerCapacity != v2.PassengerCapacity)
                return false;
            return true;
        }

        public static bool operator !=(Vehicle v1, Vehicle v2)
        {
            if (v1.Passengers.Length != v2.Passengers.Length)
                return true;
            for (int i = 0; i < v1.Passengers.Length; i++)
            {
                if (v1.Passengers[i] != v2.Passengers[i])
                    return true;
            }
            if (v1.Name != v2.Name || v1.PassengerCapacity != v2.PassengerCapacity)
                return true;
            return false;
        }

        public virtual object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}