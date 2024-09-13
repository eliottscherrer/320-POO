namespace Drones
{
    public partial class Store : Building
    {
        public string OpeningHours { get; private set; }        // Il s'agit d'une liste de chaînes de caractères du genre: "Lundi: 8h-18h","Mardi: 8h-18h","Mercredi: 8h-18h"

        public Store(int x, int y, int width, int height, Color color, string openingHours) : base(x, y, width, height, color)
        {
            OpeningHours = openingHours;
        }

        public Store(Position position, int width, int height, Color color, string openingHours) : base(position, width, height, color)
        {
            OpeningHours = openingHours;
        }
    }
}
