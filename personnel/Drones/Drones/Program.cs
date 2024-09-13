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
            List<Drone> fleet = new()
            {
                new("Joe", 100, 100)
            };

            // D�marrage
            Application.Run(new AirSpace(fleet));
        }
    }
}