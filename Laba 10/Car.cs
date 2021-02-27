using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_10
{
    public class Car : Vehicle, IInit
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

        public override void Show()
        {
            base.Show();
            Console.Write($", Number of doors: {_numberOfDoors}");
        }

        private protected new static Random random = new Random();

        public override object Init()
        {
            Vehicle b = (Vehicle)base.Init();
            string[] names = new[] { "Ламбарджини", "Ферари", "БМВ", "Легковая", "Спортивная", "Гиперкар", "Тарантайка" };
            Car car = new Car { Name = names[random.Next(0, names.Length)], PassengerCapacity = b.PassengerCapacity, NumberOfDoors = random.Next(1, 10) };
            return car;
        }
    }
}