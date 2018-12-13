using CrazyRecycling.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Controllers
{
    [TestClass]
    public class PlayerControllerTests
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
                player.PosY += 1;
                Assert.AreEqual(player.PosY, player2.PosY + 1);
                player = new Player(0, 0); player2 = new Player(0, 0);
            }

            buttonPressed = "A";
            if (buttonPressed == "A")
            {
                player.PosX -= 1;
                Assert.AreEqual(player.PosX, player2.PosX - 1);
                player = new Player(0, 0); player2 = new Player(0, 0);
            }

            buttonPressed = "S";
            if (buttonPressed == "S")
            {
                player.PosY -= 1;
                Assert.AreEqual(player.PosY, player2.PosY - 1);
                player = new Player(0, 0); player2 = new Player(0, 0);
            }
            buttonPressed = "D";

            if (buttonPressed == "D")
            {
                player.PosX += 1;
                Assert.AreEqual(player.PosX, player2.PosX + 1);
                player = new Player(0, 0); player2 = new Player(0, 0);
            }

        }
        [TestMethod]
        public void getPlayerStatsTest()
        {
            Player player; player = new Player();
            PlayerStats playerStats = player.characterClass.GetStats();
            Assert.IsNotNull(playerStats);
        }

    }
}