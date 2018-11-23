using CrazyRecycling.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Models
{
    [TestClass()]
    public class ShopTests
    {
        [TestMethod()]
        public void Shop_CreatingWithCoordinates_ShopIsCreatedAt00Size1616()
        {
            //Arrange
            Shop shop;

            //Act
            shop = new Shop(0, 0, 16, 16, 1);

            //Assert
            Assert.AreEqual(shop.PositionX, 0);
            Assert.AreEqual(shop.PositionY, 0);
            Assert.AreEqual(shop.SizeX, 16);
            Assert.AreEqual(shop.SizeY, 16);
        }
        [TestMethod()]
        public void Clone_ClonesObject_returnsShallowCopy()
        {
            //Arrange
            var shop = new Shop(0, 0, 16, 16, 1);

            //Act
            var shopClone = shop.Clone();

            //Assert
            Assert.ReferenceEquals(shop, shopClone);
        }
    }
}
