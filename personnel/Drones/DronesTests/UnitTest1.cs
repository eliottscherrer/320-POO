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
    }
}
