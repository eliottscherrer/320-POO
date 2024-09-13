namespace Drones
{
    public partial class Store : Building
    {
        // De manière graphique
        public override void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.FillEllipse(_brush, new Rectangle(Position.X, Position.Y, Width, Height));
        }

        // Dans la console
        public override void Print()
        {
            base.Print();

            Console.WriteLine($"Opening hours:");
            foreach(string openingHour in OpeningHours)
                Console.WriteLine($"\t{openingHour}");
        }
    }
}
