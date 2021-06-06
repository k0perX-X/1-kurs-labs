using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Laba_10;
using static Laba_14.Program;

namespace UnitTestsLaba14
{
    [TestClass]
    public class Tests
    {
        private static Vehicle vehicle = new Vehicle();
        private static Car car = new Car();
        private static Train train = new Train();
        private static Express express = new Express();
        private static Random random = new Random();

        private static int number = 1;

        private List<Vehicle> createList()
        {
            List<Vehicle> list = new(1000);
            for (int i = 0; i < 100000; i++)
            {
                switch (random.Next(4))
                {
                    case 0:
                        list.Add((Vehicle)vehicle.Init());
                        break;

                    case 1:
                        list.Add((Car)car.Init());
                        break;

                    case 2:
                        list.Add((Train)train.Init());
                        break;

                    case 3:
                        list.Add((Express)express.Init());
                        break;
                }
            }

            return list;
        }

        [TestMethod]
        public void PassengerCapacityTrainTest()
        {
            for (int i = 0; i < number; i++)
            {
                var l = createList();
                var t = PassengerCapacityTrain(l);
                if (t.metod != t.zapros)
                    throw new Exception($"{t.zapros} {t.metod}");
            }
        }

        [TestMethod]
        public void PassengerCapacityGraterTest()
        {
            for (int i = 0; i < number; i++)
            {
                var l = createList();
                var t = PassengerCapacityGrater(l, i / 100);
                if (t.metod != t.zapros)
                    throw new Exception($"{t.zapros} {t.metod}");
            }
        }

        [TestMethod]
        public void PassengerCapacityTrainExpressEqualTest()
        {
            for (int i = 0; i < number; i++)
            {
                var l = createList();
                var t = PassengerCapacityTrainExpressEqual(l);
                if (t.metod != t.zapros)
                    throw new Exception($"{t.zapros} {t.metod}");
            }
        }

        [TestMethod]
        public void PassengerCapacityMaxTest()
        {
            for (int i = 0; i < number; i++)
            {
                var l = createList();
                var t = PassengerCapacityMax(l);
                if (t.metod != t.zapros)
                    throw new Exception($"{t.zapros} {t.metod}");
            }
        }

        [TestMethod]
        public void GroupTest()
        {
            for (int i = 0; i < number; i++)
            {
                var l = createList();
                var t = Group(l);
                if (t.metod.vehicles.Except(t.zapros.vehicles).Count() > 0)
                    throw new Exception($"vehicles");
                if (t.metod.cars.Except(t.zapros.cars).Count() > 0)
                    throw new Exception($"cars");
                if (t.metod.trains.Except(t.zapros.trains).Count() > 0)
                    throw new Exception($"trains");
                if (t.metod.expresses.Except(t.zapros.expresses).Count() > 0)
                    throw new Exception($"expresses");
            }
        }
    }
}