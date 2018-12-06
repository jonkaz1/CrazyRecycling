using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrazyRecycling.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Controllers.Tests
{
    [TestClass()]
    public class UnitTestServerConnector
    {
        [TestMethod()]
        public void GetActionTest()
        {
            //Arrange
            ServerConnector connector = ServerConnector.Instance;
            //Act
            var task1 = Task.Run(() => connector.GetAction("Player"));
            var task2 = Task.Run(() => connector.GetAction("Player"));
            task1.Wait();
            task2.Wait();
            //Assert
            Assert.AreEqual(task1.Result, task2.Result);
        }

        [TestMethod()]        
        public void GetActionTestNotExists()
        {
            //Arrange
            ServerConnector connector = ServerConnector.Instance;
            //Act
            var task1 = Task.Run(() => connector.GetAction("Player/1"));
            task1.Wait();
            Assert.AreEqual(task1.Result, "");
        }

        [TestMethod()]
        public void GetActionTestExists()
        {
            //Arrange
            ServerConnector connector = ServerConnector.Instance;
            //Act
            var task1 = Task.Run(() => connector.GetAction("Player/146"));
            task1.Wait();
            Assert.AreNotEqual(task1.Result, "");
        }
    }
}