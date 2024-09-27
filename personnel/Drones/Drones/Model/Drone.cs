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

        public Drone(string name, Position? position = null)
        {
            Name = name;
            // If no position is provided, make it 0, 0 at default
            Position = position ?? new Position(0, 0);
            Charge = DEFAULT_CHARGE;
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
            // If the drone has no charge, it cannot evacuate
            if (Charge <= 0) return false;

            // Check if the drone is inside the no-fly zone
            bool isInsideZone = Position.X >= zone.X && Position.X <= (zone.X + zone.Width) &&
                                Position.Y >= zone.Y && Position.Y <= (zone.Y + zone.Height);

            if (isInsideZone)
            {
                EvacuationState = EvacuationState.Evacuating;

                // Update position to try and move out of the zone
                Position.X += (Position.X < zone.X) ? -Speed : (Position.X > (zone.X + zone.Width) ? Speed : 0);
                Position.Y += (Position.Y < zone.Y) ? -Speed : (Position.Y > (zone.Y + zone.Height) ? Speed : 0);

                // Check if the drone is now outside the zone
                if (Position.X < zone.X || Position.X > (zone.X + zone.Width) ||
                    Position.Y < zone.Y || Position.Y > (zone.Y + zone.Height))
                {
                    EvacuationState = EvacuationState.Evacuated;
                    return true;
                }

                // Still inside the zone even after update
                return false;
            }

            // If already outside, return true and update the state
            EvacuationState = EvacuationState.Evacuated;
            return true;
        }

        public void FreeFlight() => EvacuationState = EvacuationState.Free;

        public EvacuationState GetEvacuationState() => EvacuationState;
    }
}