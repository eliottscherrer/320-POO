using Drones.Helpers;

namespace Drones
{
    public partial class Box
    {
        private static int _idCounter = 0;
        private static Color[] _colors = { Color.Red, Color.Yellow, Color.Blue, Color.Brown, Color.Orange };

        public readonly int ID;                         // Unique identifier
        public double Weight { get; private set; }      // In kilos
        public Color Color { get; private set; }        // Red, Yellow, Blue, Brown or Orange

        public Box()
        {
            Weight = GlobalHelpers.Rand.Next(5, 11);                // Random weight between 5 and 10 kilos.
            ID = _idCounter++;                                                  // Ids start at 0
            Color = _colors[GlobalHelpers.Rand.Next(_colors.Length)];
        }

        public override string ToString() => $"Box ID: {ID}, Weight: {Weight} kg, Color: {Color}";
    }
}
