namespace Drones
{
    public partial class Store : Building
    {
        public string OpeningHours { get; private set; }        // Il s'agit d'une liste de chaînes de caractères du genre: "Lundi: 8h-18h","Mardi: 8h-18h","Mercredi: 8h-18h"

        public Store(int x, int y, int size, Color color, string openingHours) : base(x, y, size, size, color)
        {
            OpeningHours = openingHours;
            Print();
        }

        public Store(Position position, int size, Color color, string openingHours) : base(position, size, size, color)
        {
            OpeningHours = openingHours;
            Print();
        }
    }
}
