namespace Drones
{
    public abstract partial class Building
    {
        protected readonly Brush _brush;

        // De manière graphique
        public virtual void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.FillRectangle(_brush, new Rectangle(Position.X, Position.Y, Width, Height));
        }

        // Dans la console
        public virtual void Print()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Size: {Width}x{Height}");
            Console.WriteLine($"Color: {Color.Name}");
        }
    }
}
