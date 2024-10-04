using Drones.Helpers;
using System;

namespace Drones
{
    public partial class Factory : Building
    {
        ////////////////////////////////// [ CONSTS ] //////////////////////////////////
        
        

        /////////////////////////////////// [ VARS ] ///////////////////////////////////
        
        private static int _factoryCounter = 0;
        public readonly int ID;                                     // Unique identifier
        public double PowerConsumption { get; private set; }        // Nombre de KwH/jour

        ///////////////////////////////////////////////////////////////////////////////
        
        public Factory(int x, int y, int size, Color color, double powerConsumption) : base(x, y, size, size, color)
        {
            ID = _factoryCounter++;
            PowerConsumption = powerConsumption;

            Print();
        }

        public Factory(Position position, int size, Color color, double powerConsumption) : base(position, size, size, color)
        {
            ID = _factoryCounter++;
            PowerConsumption = powerConsumption;

            Print();
        }
    }
}
