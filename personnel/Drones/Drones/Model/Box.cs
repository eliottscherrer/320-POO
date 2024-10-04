using Drones.Helpers;

namespace Drones
{
    public partial class Box
    {
        ////////////////////////////////// [ CONSTS ] //////////////////////////////////

        private const int MIN_WEIGHT = 5;
        private const int MAX_WEIGHT = 10;

        /////////////////////////////////// [ VARS ] ///////////////////////////////////

        private static int _idCounter = 0;
        private static readonly Color[] _colors = { Color.Red, Color.Yellow, Color.Blue, Color.Brown, Color.Orange };

        public readonly int ID;                         // Unique identifier
        public double Weight { get; private set; }      // In kilos
        public Color Color { get; private set; }        // Red, Yellow, Blue, Brown or Orange

        ///////////////////////////////////////////////////////////////////////////////

        public Box()
        {
            ID = _idCounter++;                                                  // Ids start at 0
            Weight = GlobalHelpers.Rand.Next(MIN_WEIGHT, MAX_WEIGHT + 1);       // Random weight between 5 and 10 kilos.
            Color = _colors[GlobalHelpers.Rand.Next(_colors.Length)];
        }
    }
}
