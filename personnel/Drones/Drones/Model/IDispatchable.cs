namespace Drones.Model
{
    public interface IDispatchable
    {
        void AddBox(Box box);
        void RemoveBox(Box box);
        List<Box> GetBoxes();
    }
}
