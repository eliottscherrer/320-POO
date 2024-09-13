using Drones.Helpers;

namespace Drones
{
    public abstract partial class Building
    {
        public int X { get; private set; }                  // Position en X depuis la gauche de l'espace aérien
        public int Y { get; private set; }                  // Position en Y depuis le haut de l'espace aérien
        public int Width { get; private set; }
        public int Height { get; private set; }

        private readonly Color Color;

        public Building(int x, int y, int width, int height, Color color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
            _brush = new SolidBrush(Color);
        }
    }
}
