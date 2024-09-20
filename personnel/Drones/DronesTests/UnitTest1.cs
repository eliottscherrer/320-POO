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
        }
    }
}
