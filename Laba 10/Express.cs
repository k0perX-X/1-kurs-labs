using System;

namespace Laba_10
{
    public class Express : Train
    {
        private double speed;

        public double Speed
        {
            get => speed;
            set => speed = value;
        }

        public Express() : base()
        {
            speed = 0;
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
            Console.Write($", Speed: {speed}");
        }

        private protected new static Random random = new Random();

        public override object Init()
        {
            Train b = (Train)base.Init();

            Express express = new Express
            {
                Name = b.Name,
                PassengerCapacity = b.PassengerCapacity,
                Stations = b.Stations,
                NumberOfPassengersInTheCarriage = b.NumberOfPassengersInTheCarriage,
                Speed = random.Next(50, 501)
            };
            return express;
        }
    }
}