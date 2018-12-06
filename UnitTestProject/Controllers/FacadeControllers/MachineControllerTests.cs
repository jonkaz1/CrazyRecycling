using CrazyRecycling.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Controllers.FacadeControllers
{
    [TestClass()]
    public class MachineControllerTests
    {
        [TestMethod()]
        public void PopulateListAsShops_MethodGets10Locations_MachinesListGets10NewShops()
        {
            //Arrange
            var machineController = new MachineController();
            Collection<Point> locations = new Collection<Point>();
            for (int i = 0; i < 10; i++)
            {
                locations.Add(new Point(i, i));
            }
            //Act
            machineController.PopulateListAsShops(locations, 1);
            //Assert
            Assert.AreEqual(10, machineController.Machines.Count);
        }
        
        [TestMethod()]
        public void PopulateListAsRecyclingMachines_MethodGets10Locations_MachinesListGets10NewRecyclingMachines()
        {
            //Arrange
            var machineController = new MachineController();
            Collection<Point> locations = new Collection<Point>();
            for (int i = 0; i < 10; i++)
            {
                locations.Add(new Point(i, i));
            }
            //Act
            machineController.PopulateListAsShops(locations, 1);
            //Assert
            Assert.AreEqual(10, machineController.Machines.Count);
        }
        
    }
}
