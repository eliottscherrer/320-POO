﻿using Drones.Helpers;

namespace Drones
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Drone
    {
        private const int BRUSH_SIZE = 3;
        private static readonly Pen _brush = new(new SolidBrush(Color.Purple), BRUSH_SIZE);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawEllipse(_brush, new Rectangle(Position.X - 4, Position.Y - 2, 8, 8));
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, Position.X + 5, Position.Y - 5);
        }

        // De manière textuelle
        public override string ToString() => $"{Name} ({(int)((double)Charge / 1000 * 100)}%)";
    }
}
