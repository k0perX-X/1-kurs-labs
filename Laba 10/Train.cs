using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_10
{
    internal class Train : Vehicle
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
        }

        public Train(string name, int passengerCapacity, string[] stations) : base(name, passengerCapacity)
        {
            Stations = stations;
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
            Console.Write(", Stations: ");
            PrintMas(_stations, inOneLine: true);
            Console.Write(", Number of passengers in the carriage: ");
            PrintMas(_numberOfPassengersInTheCarriage, inOneLine: true);
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

            int numberOfNumberOfPassengersInTheCarriage = random.Next(1, 10);
            int[] numberOfPassengersInTheCarriage = new int[numberOfNumberOfPassengersInTheCarriage];
            for (int i = 0; i < numberOfNumberOfPassengersInTheCarriage; i++)
            {
                numberOfPassengersInTheCarriage[i] = random.Next(0, 100);
            }

            Train train = new Train
            {
                Name = names[random.Next(0, names.Length)],
                PassengerCapacity = b.PassengerCapacity,
                Stations = sts,
                NumberOfPassengersInTheCarriage = numberOfPassengersInTheCarriage
            };
            return train;
        }
    }
}