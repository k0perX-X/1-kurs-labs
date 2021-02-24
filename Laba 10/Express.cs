using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_10
{
    internal class Express : Train
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

        public Express(string name, int passenger_capacity, string[] stations, double speed) : base(name, passenger_capacity, stations)
        {
            Speed = speed;
        }

        public void Show()
        {
            base.Show();
            Console.Write($", Speed: {speed}");
        }
    }
}