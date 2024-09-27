namespace Drones
{
    public enum EvacuationState
    {
        Free,           // No limits applied
        Evacuating,     // Limits known, moving out of the zone
        Evacuated       // Limits known, out of the zone
    }

    public interface IExpellable
    {
        // Signal the limits of the no-fly zone 
        // Return true if the drone is already outside the zone
        public bool Evacuate(Rectangle zone);

        // Terminate the no-fly zone
        public void FreeFlight();

        // Interrogate the drone
        public EvacuationState GetEvacuationState();
    }
}
