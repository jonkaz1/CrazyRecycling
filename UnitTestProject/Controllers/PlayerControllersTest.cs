using System;
using CrazyRecycling.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Controllers
{
    [TestClass]
    public class PlayerControllersTest
    {
        [TestMethod]
        public void PlayerMoveTest()
        {
            Player player, player2;
            player = new Player(0, 0); player2 = new Player(0, 0);
            string buttonPressed;

            buttonPressed = "W";
            if (buttonPressed == "W")
            {
                player.PositionY += 1;
                Assert.AreEqual(player.PositionY, player2.PositionY + 1);
                player = new Player(0, 0); player2 = new Player(0, 0);
            }

            buttonPressed = "A";
            if (buttonPressed == "A")
            {
                player.PositionX -= 1;
                Assert.AreEqual(player.PositionX, player2.PositionX - 1);
                player = new Player(0, 0); player2 = new Player(0, 0);
            }

            buttonPressed = "S";
            if (buttonPressed == "S")
            {
                player.PositionY -= 1;
                Assert.AreEqual(player.PositionY, player2.PositionY - 1);
                player = new Player(0, 0); player2 = new Player(0, 0);
            }
            buttonPressed = "D";

            if (buttonPressed == "D")
            {
                player.PositionX += 1;
                Assert.AreEqual(player.PositionX, player2.PositionX + 1);
                player = new Player(0, 0); player2 = new Player(0, 0);
            }

        }
        [TestMethod]
        public void getPlayerStatsTest()
        {
            Player player; player = new Player();
            PlayerStats playerStats = player.CharacterClass.GetStats();
            Assert.IsNotNull(playerStats);
        }

    }
}
