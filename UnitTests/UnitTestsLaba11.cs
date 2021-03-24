using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laba_11;
using System.Collections.Generic;
using System.Diagnostics;
using Laba_10;

namespace UnitTestsLaba11
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void OperatorEqualVehicle()
        {
            for (int i = 0; i < 1; i++)
            {
                Task3.TestCollections tc = new Task3.TestCollections();
                for (int x = 0; x < tc.col1.Count; x++)
                    foreach (KeyValuePair<Vehicle, Car> pair in tc.col3)
                    {
                        if ((pair.Key == tc.col1[x].BaseVehicle) !=
                            (pair.Key.ToString() == tc.col1[x].BaseVehicle.ToString()))
                            Debug.Print((pair.Key == tc.col1[x].BaseVehicle).ToString() + pair.Key.ToString());
                    }
            }
        }
    }
}