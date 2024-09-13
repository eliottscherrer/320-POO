namespace Drones
{
    public partial class Factory : Building
    {
        // Dans la console
        public override void Print()
        {
            base.Print();

            Console.WriteLine($"Power Consumption: {PowerConsumption} KwH/day");
        }
    }
}
