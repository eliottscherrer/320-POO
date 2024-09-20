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
            Assert.AreEqual(1000, drone.Charge, "La charge du drone doit être de 1000");
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
            Assert.IsTrue(initialCharge > drone.Charge, "La charge du drone doit réduire après une update");
        }

        [TestMethod]
        public void Drone_BatteryBelow20Percent_LowBatteryIsTrue()
        {
            // Arrange
            Drone drone = new Drone("test", new Position(50, 50));

            // Action
            // On update le drone jusqu'à ce qu'il soit à moins de 20% de sa charge complète
            while (drone.Charge < Drone.DEFAULT_CHARGE / 5)
                drone.Update(1);

            // Assert
            Assert.IsTrue(drone.LowBattery, "La propriété `Lowbattery` du drone est `true` quand la charge est plus petite que 20");
        }

        [TestMethod]
        public void Drone_Update_NoEffectWhenBatteryIsZero()
        {
            // Arrange
            Drone drone = new Drone("test", new Position(50, 50));

            // Action
            // On update le drone jusqu'à qu'il soit à moins de 20% de sa charge complète
            while (drone.Charge < Drone.DEFAULT_CHARGE / 5)
                drone.Update(1);

            // Assert
            Assert.IsTrue(drone.LowBattery, "La propriété `Lowbattery` du drone est `true` quand la charge est plus petite que 20");
        }
    }
}
