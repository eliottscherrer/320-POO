using Drones.Helpers;

namespace Drones
{
    public abstract partial class Building
    {
        public Position Position { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        private readonly Color Color;

        protected Building(int x, int y, int width, int height, Color color)
        {
            Position = new Position(x, y);
            Width = width;
            Height = height;
            Color = color;
            _brush = new SolidBrush(Color);
        }

        protected Building(Position position, int width, int height, Color color)
        {
            Position = position;
            Width = width;
            Height = height;
            Color = color;
            _brush = new SolidBrush(Color);
        }
    }
}
