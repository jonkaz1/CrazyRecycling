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
    public class RecyclingMachineTests
    {
        [TestMethod()]
        public void RecyclingMachine_CreatingWithCoordinates_RecyclingMachineIsCreatedAt00Size1616()
        {
            //Arrange
            RecyclingMachine recyclingMachine;

            //Act
            recyclingMachine = new RecyclingMachine(0, 0, 16, 16, 1);

            //Assert
            Assert.AreEqual(recyclingMachine.PosX, 0);
            Assert.AreEqual(recyclingMachine.PosY, 0);
            Assert.AreEqual(recyclingMachine.SizeX, 16);
            Assert.AreEqual(recyclingMachine.SizeY, 16);
        }
        [TestMethod()]
        public void Clone_ClonesObject_returnsShallowCopy()
        {
            //Arrange
            var recyclingMachine = new RecyclingMachine(0, 0, 16, 16, 1);

            //Act
            var recyclingMachineClone = recyclingMachine.Clone();

            //Assert
            Assert.ReferenceEquals(recyclingMachine, recyclingMachineClone);
        }
    }
}
