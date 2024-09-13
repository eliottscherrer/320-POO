using Drones.Helpers;
using System.Drawing;

namespace Drones
{
    public partial class Building
    {
        protected readonly Brush _brush;

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.FillRectangle(_buildingBrush, new Rectangle(X, Y, Width, Height));
        }
    }
}
