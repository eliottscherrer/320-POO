using Drones.Helpers;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Drone : IExpellable
    {
        ////////////////////////////// [ CONST ] //////////////////////////////

        public const int DEFAULT_CHARGE = 1000;
        private const int DEFAULT_SPEED = 2;

        /////////////////////////////// [ VAR ] ///////////////////////////////

        public string Name { get; private set; }
        public Position Position { get; private set; }
        public int Charge { get; private set; }
        public bool LowBattery { get; private set; }
        public int Speed { get; private set; }
        private EvacuationState EvacuationState { get; set; }

        ///////////////////////////////////////////////////////////////////////

        public Drone(string name, int x, int y)
        {
            Name = name;
            Position = new Position(x, y);
            Charge = DEFAULT_CHARGE;
            LowBattery = false;
            Speed = DEFAULT_SPEED;
            EvacuationState = EvacuationState.Free;
        }

        public Drone(string name, Position position)
        {
            Name = name;
            Position = position;
            Charge = DEFAULT_CHARGE;
            LowBattery = false;
            Speed = DEFAULT_SPEED;
            EvacuationState = EvacuationState.Free;
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            // Don't update if the drone's charge is depleted
            if (Charge <= 0) return;

            // Move
            Position.X += Speed;
            Position.Y += GlobalHelpers.Rand.Next(-Speed, Speed + 1);

            // Decrease charge
            Charge -= interval / 100;
            if (Charge < 0) Charge = 0;

            // If charge is below 20%, LowBattery mode activates
            if (Charge < DEFAULT_CHARGE / 5)
                LowBattery = true;
        }

        public bool Evacuate(Rectangle zone)
        {
            throw new NotImplementedException();
        }

        public void FreeFlight()
        {
            throw new NotImplementedException();
        }

        public EvacuationState GetEvacuationState()
        {
            throw new NotImplementedException();
        }

        public void FreeFlight() => EvacuationState = EvacuationState.Free;

        public EvacuationState GetEvacuationState() => EvacuationState;
    }
}