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
            Drone drone = new("test", new Position(50, 50));

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
            Drone drone = new("test", new Position(50, 50));

            // Action
            // Quickly reduce the battery to below 20%
            while (drone.Charge >= Drone.DEFAULT_CHARGE / 5)
                drone.Update(100); // Using 100 as the interval to speed up the reduction

            // Assert
            Assert.IsTrue(drone.LowBattery, "The drone's `LowBattery` property should be true when charge is below 20%.");
        }

        [TestMethod]
        public void Drone_Update_NoEffectWhenBatteryIsZero()
        {
            // Arrange
            Drone drone = new("test", new Position(50, 50));

            // Action
            // Drain the battery to 0
            while (drone.Charge > 0)
                drone.Update(100);

            // Store the position and charge before attempting another update
            Position lastPosition = drone.Position;
            int lastCharge = drone.Charge;

            drone.Update(1);

            // Assert
            Assert.AreEqual(lastCharge, drone.Charge, "The charge should not decrease further when it's 0.");
            Assert.AreEqual(lastPosition, drone.Position, "The position should not change when the battery is 0.");
        }


        [TestMethod]
        public void Test_that_drone_is_taking_orders()
        {
            // Arrange
            Drone drone = new("test", new Position(500, 500));

            // Act
            EvacuationState state = drone.GetEvacuationState();

            // Assert
            Assert.AreEqual(EvacuationState.Free, state);

            // Arrange a no-fly zone around the drone
            bool response = drone.Evacuate(new System.Drawing.Rectangle(400, 400, 200, 200));

            // Assert
            Assert.IsFalse(response); // because the zone is around the drone
            Assert.AreEqual(EvacuationState.Evacuating, drone.GetEvacuationState());

            // Arrange: remove no-fly zone
            drone.FreeFlight();

            // Assert
            Assert.AreEqual(EvacuationState.Free, drone.GetEvacuationState());
        }
    }
}
