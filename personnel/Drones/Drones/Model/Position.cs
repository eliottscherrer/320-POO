namespace Drones
{
    public class Position
    {
        public int X { get; set; }     // Position en X depuis la gauche de l'espace aérien
        public int Y { get; set; }     // Position en Y depuis le haut de l'espace aérien

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X}, {Y})";
    }
}
