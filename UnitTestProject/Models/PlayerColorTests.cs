using System;
using CrazyRecycling.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Models
{
    [TestClass]
    public class PlayerColorTests
    {
        [TestMethod]
        public void TestDefaultPlayerColor_TestHoarderClassPlayerColor()
        {
            Player MainPlayer = new Player();

            Assert.AreEqual(MainPlayer.Color.GetColor().Name, "Black");

            MainPlayer.SetClass("Hoarder");
            Assert.AreEqual(MainPlayer.Color.GetColor().Name, "LawnGreen");

            MainPlayer.SetClass("Speedy");
            Assert.AreEqual(MainPlayer.Color.GetColor().Name, "LightBlue");
        }

    }
}
