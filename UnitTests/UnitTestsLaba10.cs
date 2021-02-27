using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laba_10;

namespace UnitTestsLaba10
{
    [TestClass]
    public class InitTests
    {
        [TestMethod]
        public void PassengerInitCheck()
        {
            new Passenger();
        }

        [TestMethod]
        public void VehicleInitCheck()
        {
            new Vehicle();
            new Vehicle("Name", 123);
            new Vehicle("Name", 123, new[] { new Passenger() });
        }

        [TestMethod]
        public void CarInitCheck()
        {
            new Car("Name", 123, 5);
            new Car();
        }

        [TestMethod]
        public void TrainInitCheck()
        {
            new Train();
            new Train("Name", 23, new[] { "station" });
            new Train("Name", 23, new[] { "station" }, new[] { 1, 2, 3 });
        }

        [TestMethod]
        public void ExpressInitCheck()
        {
            new Express();
            new Express("Name", 123, new[] { "Station" }, 500);
            new Express("Name", 123, new[] { "Station" }, new[] { 1, 2, 3 }, 500);
        }
    }

    [TestClass]
    public class RandomInit
    {
        [TestMethod]
        public void PassengerInitCheck()
        {
            new Passenger().Init();
        }

        [TestMethod]
        public void VehicleInitCheck()
        {
            new Vehicle().Init();
        }

        [TestMethod]
        public void CarInitCheck()
        {
            new Car().Init();
        }

        [TestMethod]
        public void TrainInitCheck()
        {
            new Train().Init();
        }

        [TestMethod]
        public void ExpressInitCheck()
        {
            new Express().Init();
        }
    }

    [TestClass]
    public class Clone
    {
        [TestMethod]
        public void DeepClone()
        {
            new Vehicle().Clone();
            Debug.Print("1 done");
            new Vehicle()
            {
                Passengers = new Passenger[]
                {
                    new Passenger(),
                }
            }.Clone();
            Debug.Print("2 done");
            new Vehicle()
            {
                Name = "Name",
                PassengerCapacity = 123,
                Passengers = new Passenger[]
                {
                    new Passenger(),
                    new Passenger()
                }
            }.Clone();
            Debug.Print("3 done");
        }

        [TestMethod]
        public void ShallowCopy()
        {
            new Vehicle().ShallowCopy();
            new Vehicle()
            {
                Passengers = new Passenger[]
                {
                    new Passenger(),
                }
            }.ShallowCopy();
            new Vehicle()
            {
                Name = "Name",
                PassengerCapacity = 123,
                Passengers = new Passenger[]
                {
                    new Passenger(),
                    new Passenger()
                }
            }.ShallowCopy();
        }
    }

    [TestClass]
    public class Show
    {
        [TestMethod]
        public void Passenger()
        {
            new Passenger().Show();
            new Passenger
            {
                Name = "Name",
                Station = "Station"
            }.Show();
        }

        [TestMethod]
        public void Vehicle()
        {
            new Vehicle().Show();
            new Vehicle("Name", 123).Show();
            new Vehicle("Name", 123, new[] { new Passenger() }).Show();
        }

        [TestMethod]
        public void Car()
        {
            new Car("Name", 123, 5).Show();
            new Car().Show();
        }

        [TestMethod]
        public void Train()
        {
            new Train().Show();
            new Train("Name", 23, new[] { "station" }).Show();
        }

        [TestMethod]
        public void Express()
        {
            new Express().Show();
            new Express("Name", 123, new[] { "Station" }, 500).Show();
        }
    }
}