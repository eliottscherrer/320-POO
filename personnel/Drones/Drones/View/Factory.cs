namespace Drones
{
    public partial class Factory : Building
    {
        // De manière graphique
        public override void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.FillRectangle(_brush, new Rectangle(Position.X, Position.Y, Width, Height));
        }

        // Dans la console
        public override void Print()
        {
            base.Print();

            Console.WriteLine($"Power Consumption: {PowerConsumption} KwH/day");
        }
    }
}
