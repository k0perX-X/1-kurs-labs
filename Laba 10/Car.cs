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
            string[] names = new[] { "Ламбарджини", "Ферари", "БМВ", "Легковая", "Спортивная", "Гиперкар", "Тарантайка", "Десятка", "Ведро с гайками", "Гранта", "Веста", "Поло", "Фьюжн", "Форд", "Фиат" };
            int passengerCapacity = random.Next(2, 11);
            Passenger[] passengers = new Passenger[random.Next(0, passengerCapacity)];
            Passenger passenger = new Passenger();
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = (Passenger)passenger.Init();
            }
            Car car = new Car
            {
                Name = names[random.Next(0, names.Length)],
                PassengerCapacity = passengerCapacity,
                NumberOfDoors = random.Next(2, 10),
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

        public override string ToString()
        {
            return base.ToString() + $", Number of doors: {_numberOfDoors}";
        }

        public Vehicle BaseVehicle
        {
            get
            {
                return new Vehicle(Name, PassengerCapacity, Passengers);
            }
        }
    }
}