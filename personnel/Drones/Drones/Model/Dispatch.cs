using Drones.Model;

namespace Drones
{
    public class Dispatch : IDispatchable
    {
        private readonly List<Box> _producedBoxes;

        public Dispatch()
        {
            _producedBoxes = new List<Box>();
        }

        public void AddBox(Box box)
        {
            _producedBoxes.Add(box);
            Console.WriteLine($"Dispatch received:" +
                                    $"\n\t{box}");
        }

        public void RemoveBox(Box box)
        {
            if (_producedBoxes.Contains(box))
            {
                _producedBoxes.Remove(box);
                Console.WriteLine($"Box {box.ID} removed from Dispatch");
            }
        }

        public List<Box> GetBoxes() => _producedBoxes;
    }
}
