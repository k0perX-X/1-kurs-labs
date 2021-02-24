using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_10
{
    internal class Train : Vehicle
    {
        private string[] _stations;

        public string[] Stations
        {
            get => _stations;
            set => _stations = value;
        }

        public Train() : base()
        {
            _stations = default;
        }

        public Train(string name, int passengerCapacity, string[] stations) : base(name, passengerCapacity)
        {
            Stations = stations;
        }

        private void PrintMas(string[] mas, bool bracket = true, bool inOneLine = false)
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

        public void Show()
        {
            base.Show();
            Console.Write($", Stations: ");
            PrintMas(_stations, inOneLine: true);
        }
    }
}