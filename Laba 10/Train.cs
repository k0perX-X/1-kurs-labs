using System;

namespace Laba_10
{
    public class Train : Vehicle
    {
        private int[] _numberOfPassengersInTheCarriage;
        private string[] _stations;

        public string[] Stations
        {
            get => _stations;
            set => _stations = value;
        }

        public int[] NumberOfPassengersInTheCarriage
        {
            get => _numberOfPassengersInTheCarriage;
            set => _numberOfPassengersInTheCarriage = value;
        }

        public Train() : base()
        {
            _stations = default;
            _numberOfPassengersInTheCarriage = default;
        }

        public Train(string name, int passengerCapacity, string[] stations) : base(name, passengerCapacity)
        {
            Stations = stations;
            _numberOfPassengersInTheCarriage = default;
        }

        public Train(string name, int passengerCapacity, string[] stations, int[] numberOfPassengersInTheCarriage) : base(name, passengerCapacity)
        {
            Stations = stations;
            _numberOfPassengersInTheCarriage = numberOfPassengersInTheCarriage;
        }

        private protected void PrintMas(string[] mas, bool bracket = true, bool inOneLine = false)
        {
            if (mas.Length > 0)
            {
                if (bracket) Console.Write("[");
                for (int i = 0; i < mas.Length - 1; i++)
                    Console.Write($"{mas[i]}, ");
                Console.Write(mas[^1]);
                if (bracket) Console.Write("]");
                if (!inOneLine)
                    Console.WriteLine();
            }
            else
                if (bracket)
                if (!inOneLine)
                    Console.WriteLine("Массив пустой");
                else
                    Console.Write("Массив пустой");
        }

        private protected void PrintMas(int[] mas, bool bracket = true, bool inOneLine = false)
        {
            if (mas.Length > 0)
            {
                if (bracket) Console.Write("[");
                for (int i = 0; i < mas.Length - 1; i++)
                    Console.Write($"{mas[i]}, ");
                Console.Write(mas[^1]);
                if (bracket) Console.Write("]");
                if (!inOneLine)
                    Console.WriteLine();
            }
            else
            if (bracket)
                if (!inOneLine)
                    Console.WriteLine("Массив пустой");
                else
                    Console.Write("Массив пустой");
        }

        public override void Show()
        {
            base.Show();
            if (Stations != null)
            {
                Console.Write(", Stations: ");
                PrintMas(_stations, inOneLine: true);
            }
            if (NumberOfPassengersInTheCarriage != null)
            {
                Console.Write(", Number of passengers in the carriage: ");
                PrintMas(_numberOfPassengersInTheCarriage, inOneLine: true);
            }
        }

        private protected new static Random random = new Random();

        public override object Init()
        {
            Vehicle b = (Vehicle)base.Init();
            string[] names = new[]
            {
                "Скорый", "Пригородный", "Междугородний", "Дальнего следования", "Метро",
                "Внутригородской", "Трамвай"
            };
            string[] st = new[]
            {
                "Заводская", "Воздушная", "Хлебозаводская", "Народная", "32 км", "Центральная",
                "Конечная"
            };

            int numberOfStations = random.Next(0, 4);
            string[] sts = new string[numberOfStations];
            for (int i = 0; i < numberOfStations; i++)
            {
                sts[i] = st[random.Next(0, numberOfStations)];
            }

            int[] numberOfPassengersInTheCarriage = new int[random.Next(1, 10)];
            for (int i = 0; i < numberOfPassengersInTheCarriage.Length; i++)
            {
                numberOfPassengersInTheCarriage[i] = random.Next(0, 100);
            }

            int numberOfPassengersInTheCarriageSumm = 0;
            for (int i = 0; i < numberOfPassengersInTheCarriage.Length; i++)
                numberOfPassengersInTheCarriageSumm += numberOfPassengersInTheCarriage[i];

            Passenger[] passengers = new Passenger[numberOfPassengersInTheCarriageSumm];
            Passenger passenger = new Passenger();
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = (Passenger)passenger.Init();
            }

            Train train = new Train
            {
                Name = names[random.Next(0, names.Length)],
                PassengerCapacity = b.PassengerCapacity,
                Stations = sts,
                Passengers = passengers,
                NumberOfPassengersInTheCarriage = numberOfPassengersInTheCarriage
            };
            return train;
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
                return new Train
                {
                    Name = this.Name,
                    PassengerCapacity = this.PassengerCapacity,
                    Passengers = passengers,
                    Stations = this._stations,
                    NumberOfPassengersInTheCarriage = this._numberOfPassengersInTheCarriage
                };
            }
            else
            {
                return new Train
                {
                    Name = this.Name,
                    PassengerCapacity = this.PassengerCapacity,
                    Passengers = default,
                    Stations = this._stations,
                    NumberOfPassengersInTheCarriage = this._numberOfPassengersInTheCarriage
                };
            }
        }

        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}