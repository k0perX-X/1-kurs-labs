using System;

namespace Laba_10
{
    public class Express : Train
    {
        private double _speed;

        public double Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public Express() : base()
        {
            _speed = 0;
        }

        public Express(string name, int passengerCapacity, string[] stations, double speed) : base(name, passengerCapacity, stations)
        {
            Speed = speed;
        }

        public Express(string name, int passengerCapacity, string[] stations, int[] numberOfPassengersInTheCarriage, double speed) : base(name, passengerCapacity, stations, numberOfPassengersInTheCarriage)
        {
            Speed = speed;
        }

        public override void Show()
        {
            base.Show();
            Console.Write($", Speed: {_speed}");
        }

        private protected static Random Random = new Random();

        public override object Init()
        {
            Train b = (Train)base.Init();

            Express express = new Express
            {
                Name = b.Name,
                PassengerCapacity = b.PassengerCapacity,
                Stations = b.Stations,
                NumberOfPassengersInTheCarriage = b.NumberOfPassengersInTheCarriage,
                Passengers = b.Passengers,
                Speed = Random.Next(50, 501)
            };
            return express;
        }

        public override object Clone()
        {
            if (Passengers != null)
            {
                Passenger[] passengers = new Passenger[Passengers.Length];
                for (int i = 0; i < passengers.Length; i++)
                {
                    passengers[i] = (Passenger)Passengers[i].Clone();
                }
                return new Express
                {
                    Name = this.Name,
                    PassengerCapacity = this.PassengerCapacity,
                    Passengers = passengers,
                    Stations = this.Stations,
                    NumberOfPassengersInTheCarriage = this.NumberOfPassengersInTheCarriage,
                    Speed = this.Speed
                };
            }
            else
            {
                return new Express
                {
                    Name = this.Name,
                    PassengerCapacity = this.PassengerCapacity,
                    Passengers = default,
                    Stations = this.Stations,
                    NumberOfPassengersInTheCarriage = this.NumberOfPassengersInTheCarriage,
                    Speed = this.Speed
                };
            }
        }

        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}