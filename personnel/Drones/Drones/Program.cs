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
                new(50, 50, 50, 50, Color.Blue),
                new(150, 150, 75, 50, Color.Blue),
                new(250, 250, 50, 90, Color.Blue),
            };

            // Démarrage
            Application.Run(new AirSpace(Fleet, Buildings));
        }
    }
}