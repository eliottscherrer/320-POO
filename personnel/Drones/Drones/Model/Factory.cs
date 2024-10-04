using Drones.Helpers;
using System;

namespace Drones
{
    public partial class Factory : Building
    {
        ////////////////////////////////// [ CONSTS ] //////////////////////////////////
        
        private const int MINIMUM_PRODUCTION_INTERVAL = 5000;       // Minimum interval before a box is produced, in milliseconds

        /////////////////////////////////// [ VARS ] ///////////////////////////////////
        
        private static int _factoryCounter = 0;
        public readonly int ID;                                     // Unique identifier
        private int _timeSinceLastProduction;                       // In milliseconds
        public double PowerConsumption { get; private set; }        // Nombre de KwH/jour

        ///////////////////////////////////////////////////////////////////////////////
        
        public Factory(int x, int y, int size, Color color, double powerConsumption) : base(x, y, size, size, color)
        {
            ID = _factoryCounter++;
            PowerConsumption = powerConsumption;
            _timeSinceLastProduction = 0;

            Print();
        }

        public Factory(Position position, int size, Color color, double powerConsumption) : base(position, size, size, color)
        {
            ID = _factoryCounter++;
            PowerConsumption = powerConsumption;
            _timeSinceLastProduction = 0;

            Print();
        }

        public void Update(int interval)
        {
            _timeSinceLastProduction += interval;

            // Verify if 5 seconds +-1500ms passed
            if (_timeSinceLastProduction >= MINIMUM_PRODUCTION_INTERVAL + GlobalHelpers.Rand.Next(0, 1500))
            {
                Box newBox = new Box();
                Console.WriteLine($"Factory {ID} produced box" +
                                        $"\n\t{newBox}");

                _timeSinceLastProduction = 0;
            }
        }
    }
}
