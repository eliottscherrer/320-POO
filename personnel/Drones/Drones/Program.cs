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

            // Création de la flotte de drones
            List<Drone> Fleet = new()
            {
                new("Joe", 100, 100)
            };

            List<Building> Buildings = new()
            {
                new Factory(new Position(50, 50), 50, Color.Blue, 78.9),
                new Store(new Position(150, 150), 75, Color.Green, "Mercredi: 8h-18h"),
            };

            // Démarrage
            Application.Run(new AirSpace(Fleet, Buildings));
        }
    }
}