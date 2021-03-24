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
            string[] names = new[] { "Николай", "Игорь", "Никита", "Илья", "Маша", "Марина", "Катя", "Дима", "Юра", "Евгений", "Ева", "Оля", "Максим", "Даша", "Рита", "Паша", "Захар", "Валентина", "Анна" };
            string[] st = new[]
            {
                "Заводская", "Воздушная", "Хлебозаводская", "Народная", "32 км", "Центральная", "ВУЗ", "НИУ ВШЭ", "Сталинградская",
                "Конечная", "Пермская", "101 км", "Машиностроительная", "Новая", "Дальневосточная", "Пермская"
            };
            Passenger passenger = new Passenger
            {
                Name = names[random.Next(0, names.Length)],
                Station = st[random.Next(0, st.Length)]
            };
            return passenger;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Station: {Station}";
        }

        public void Show()
        {
            Console.Write($"Name: {Name}, Station: {Station}");
        }

        public static bool operator ==(Passenger p1, Passenger p2)
        {
            if (p1.Name == p2.Name && p2.Station == p1.Station)
                return true;
            else
                return false;
        }

        public static bool operator !=(Passenger p1, Passenger p2)
        {
            if (p1.Name == p2.Name && p2.Station == p1.Station)
                return false;
            else
                return true;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}