using System;

namespace Laba_10
{
    public class Car : Vehicle
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
            Passenger[] passengers = new Passenger[random.Next(1, 10)];
            Passenger passenger = new Passenger();
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = (Passenger)passenger.Init();
            }
            Car car = new Car
            {
                Name = names[random.Next(0, names.Length)],
                PassengerCapacity = b.PassengerCapacity,
                NumberOfDoors = random.Next(1, passengers.Length),
                Passengers = passengers
            };
            return car;
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
                return new Car
                {
                    Name = this.Name,
                    PassengerCapacity = this.PassengerCapacity,
                    NumberOfDoors = this._numberOfDoors,
                    Passengers = passengers
                };
            }
            else
            {
                return new Car
                {
                    Name = this.Name,
                    PassengerCapacity = this.PassengerCapacity,
                    NumberOfDoors = this._numberOfDoors,
                    Passengers = default
                };
            }
        }

        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}