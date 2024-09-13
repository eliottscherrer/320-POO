namespace Drones
{
    public partial class Store : Building
    {
        // De manière graphique
        public override void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.FillEllipse(_brush, new Rectangle(X, Y, Width, Height));
        }

        // Dans la console
        public override void Print()
        {
            base.Print();

            Console.WriteLine($"Opening hours: {OpeningHours}");
        }
    }
}
