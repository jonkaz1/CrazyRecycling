using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrazyRecycling.Models.Bottles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Bottles.Tests
{
    [TestClass()]
    public class AbstractFactoryTests
    {
        [TestMethod()]
        public void TypeTest()
        {
            AbstractFactory factory = new PointBottleFactory();

            Assert.IsInstanceOfType(factory, typeof(AbstractFactory));
            Assert.IsInstanceOfType(factory, typeof(PointBottleFactory));

            factory = new SpecialBottleFactory();

            Assert.IsInstanceOfType(factory, typeof(SpecialBottleFactory));
        }

        [TestMethod()]
        public void CreateBottleTest()
        {
            AbstractFactory factory = new PointBottleFactory();
           
            var bottle = factory.CreateBottle("Vodka");

            Assert.IsNull(bottle);

            bottle = factory.CreateBottle("Cola");

            Assert.IsInstanceOfType(bottle, typeof(Cola));



            factory = new SpecialBottleFactory();
            bottle = factory.CreateBottle("Cola");
            
            Assert.IsNull(bottle);

            bottle = factory.CreateBottle("Vodka");

            Assert.IsInstanceOfType(bottle, typeof(Vodka));
        }

        [TestMethod()]
        public void BottleInfoGetTest()
        {
            AbstractFactory factory = new PointBottleFactory();

            var bottle = factory.CreateBottle("NukeCola");

            Assert.AreEqual(int.Parse(bottle.GetBottleInfo()), 5);

            factory = new SpecialBottleFactory();

            bottle = factory.CreateBottle("GinOfDestruction");

            Assert.AreEqual(int.Parse(bottle.GetBottleInfo()), 10);
        }
    }
}