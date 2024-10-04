using Drones;
using System.Drawing;

namespace DronesTests
{
    [TestClass]
    public class DispatchTests
    {

        [TestMethod]
        public void Test_AddBox()
        {
            // Arrange
            Dispatch dispatch = new Dispatch();
            Box box = new Box();

            // Act
            dispatch.AddBox(box);

            // Assert
            Assert.AreEqual(1, dispatch.GetBoxes().Count);
            Assert.IsTrue(dispatch.GetBoxes().Contains(box));
        }

        [TestMethod]
        public void Test_RemoveBox()
        {
            // Arrange
            Dispatch dispatch = new Dispatch();
            Box box = new Box();
            dispatch.AddBox(box);

            // Act
            dispatch.RemoveBox(box);

            // Assert
            Assert.AreEqual(0, dispatch.GetBoxes().Count);
            Assert.IsFalse(dispatch.GetBoxes().Contains(box));
        }

        [TestMethod]
        public void Test_GetBoxes()
        {
            // Arrange
            Dispatch dispatch = new Dispatch();
            dispatch.AddBox(new Box());

            // Act
            List<Box> boxes = dispatch.GetBoxes();

            // Assert
            Assert.IsNotNull(boxes);
            Assert.AreNotEqual(0, boxes.Count);
        }

        [TestMethod]
        public void Test_Factory_Produces_Box_After_Interval()
        {
            // Arrange
            Dispatch dispatch = new Dispatch();
            Factory factory = new Factory(new Position(0, 0), 10, Color.Red, 100, dispatch);
            int maxInterval = Factory.MINIMUM_PRODUCTION_INTERVAL + Factory.MAXIMUM_INTERVAL_VARIATION;

            // Act
            factory.Update(maxInterval);
            List<Box> producedBoxes = dispatch.GetBoxes();

            // Assert
            Assert.AreEqual(1, producedBoxes.Count);
        }
    }
}
