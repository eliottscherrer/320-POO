using Drones.Helpers;

namespace Drones
{
    public partial class Factory : Building
    {
        public double PowerConsumption { get; private set; }        // Nombre de KwH/jour
        public Factory(int x, int y, int size, Color color, double powerConsumption) : base(x, y, size, size, color)
        {
            PowerConsumption = powerConsumption;
        }
    }
}
