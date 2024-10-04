using Drones;

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
    }
}
