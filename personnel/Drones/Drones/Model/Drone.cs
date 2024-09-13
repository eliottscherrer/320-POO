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

        public string Name { get; private set; }                            // Un nom
        public int X { get; private set; }                                  // Position en X depuis la gauche de l'espace aérien
        public int Y { get; private set; }                                  // Position en Y depuis le haut de l'espace aérien
        public int Charge { get; private set; }                             // La charge actuelle de la batterie
        public int Speed { get; private set; }                              // La charge actuelle de la batterie

        ///////////////////////////////////////////////////////////////////////

        public Drone(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
            Charge = DEFAULT_CHARGE;
            Speed = DEFAULT_SPEED;
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            X += Speed;
            Y += GlobalHelpers.Rand.Next(-Speed, Speed + 1);
            Charge--;
        }
    }
}
