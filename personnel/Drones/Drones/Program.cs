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
            List<Drone> fleet = new()
            {
                new("Joe", 100, 100)
            };

            // Démarrage
            Application.Run(new AirSpace(fleet));
        }
    }
}