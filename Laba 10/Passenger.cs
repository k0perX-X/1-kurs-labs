using System;

namespace Laba_10
{
    public class Passenger : IInit
    {
        private string _station;
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Station
        {
            get => _station;
            set => _station = value;
        }

        public Passenger()
        {
            _station = default;
            _name = default;
        }

        private protected static Random random = new Random();

        public virtual object Init()
        {
            string[] names = new[] { "Николай", "Игорь", "Никита", "Илья", "Маша", "Марина", "Катя" };
            string[] st = new[]
            {
                "Заводская", "Воздушная", "Хлебозаводская", "Народная", "32 км", "Центральная",
                "Конечная"
            };
            Passenger passenger = new Passenger
            {
                Name = names[random.Next(0, names.Length)],
                Station = st[random.Next(0, st.Length)]
            };
            return passenger;
        }

        public void Show()
        {
            Console.Write($"Name: {Name}, Station: {Station}");
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}