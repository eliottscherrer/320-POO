namespace Drones
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Cr�ation de la flotte de drones
            List<Drone> Fleet =
            [
                new("Joe", new Position(100, 100))
            ];

            List<Building> Buildings =
            [
                new Factory(new Position(50, 50), 50, Color.Blue, 78.9, new Dispatch()),
                new Store(new Position(150, 150), 75, Color.Green, [ "Lundi: 8h-18h", "Mardi: 8h-18h", "Mercredi: 8h-18h" ]),
            ];

            // D�marrage
            Application.Run(new AirSpace(Fleet, Buildings));
        }
    }
}