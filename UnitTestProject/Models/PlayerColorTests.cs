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

            MainPlayer.setClass("Hoarder");
            Assert.AreEqual(MainPlayer.Color.GetColor().Name, "LawnGreen");

            MainPlayer.setClass("Speedy");
            Assert.AreEqual(MainPlayer.Color.GetColor().Name, "LightBlue");
        }

    }
}
