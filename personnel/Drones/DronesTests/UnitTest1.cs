using Drones;

namespace DronesTest
{
    [TestClass]
    public class DronesTest
    {
        [TestMethod]
        public void Drone_NewDrone_HasInitialChargeOf1000()
        {
            // Arrange
            Drone drone;

            // Action
            drone = new Drone("test", new Position(50, 50));

            // Assert
            Assert.AreEqual(1000, drone.Charge, "La charge du drone doit �tre de 1000");
        }

        [TestMethod]
        public void Drone_Update_ReducesBatteryCharge()
        {
            // Arrange
            Drone drone = new Drone("test", new Position(50, 50));

            // Action
            int initialCharge = drone.Charge;
            drone.Update(1);

            // Assert
            Assert.IsTrue(initialCharge > drone.Charge, "La charge du drone doit r�duire apr�s une update");
        }

        [TestMethod]
        public void Drone_BatteryBelow20Percent_LowBatteryIsTrue()
        {
            // Arrange
            Drone drone = new Drone("test", new Position(50, 50));

            // Action
            // On update le drone jusqu'� ce qu'il soit � moins de 20% de sa charge compl�te
            while (drone.Charge < Drone.DEFAULT_CHARGE / 5)
                drone.Update(1);

            // Assert
            Assert.IsTrue(drone.LowBattery, "La propri�t� `Lowbattery` du drone est `true` quand la charge est plus petite que 20");
        }
        }
    }
}
