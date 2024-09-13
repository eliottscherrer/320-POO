using Drones.Helpers;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Drone
    {
        ////////////////////////////// [ CONST ] //////////////////////////////

        private const int DEFAULT_CHARGE = 1000;
        private const int DEFAULT_SPEED = 2;

        /////////////////////////////// [ VAR ] ///////////////////////////////

        public string Name { get; private set; }
        public Position Position { get; private set; }
        public int Charge { get; private set; }
        public int Speed { get; private set; }

        ///////////////////////////////////////////////////////////////////////

        public Drone(string name, int x, int y)
        {
            Name = name;
            Position = new Position(x, y);
            Charge = DEFAULT_CHARGE;
            Speed = DEFAULT_SPEED;
        }

        public Drone(string name, Position position)
        {
            Name = name;
            Position = position;
            Charge = DEFAULT_CHARGE;
            Speed = DEFAULT_SPEED;
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            Position.X += Speed;
            Position.Y += GlobalHelpers.Rand.Next(-Speed, Speed + 1);
            Charge--;
        }
    }
}
