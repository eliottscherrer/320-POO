namespace Drones
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class AirSpace : Form
    {
        public const int WIDTH = 1200;        // Dimensions of the airspace
        public const int HEIGHT = 600;

        // La flotte est l'ensemble des drones qui évoluent dans notre espace aérien
        private readonly List<Drone> _fleet;
        private readonly List<Building> _buildings;

        private readonly BufferedGraphicsContext currentContext;
        private readonly BufferedGraphics airspace;

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public AirSpace(List<Drone> fleet, List<Building> buildings)
        {
            InitializeComponent();
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            airspace = currentContext.Allocate(CreateGraphics(), DisplayRectangle);
            _fleet = fleet;
            _buildings = buildings;
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.Clear(Color.AliceBlue);

            // draw drones
            foreach (Drone drone in _fleet)
            {
                drone.Render(airspace);
            }

            // Draw buildings
            foreach (Building building in _buildings)
            {
                switch (building)
                {
                    case Store store:
                        store.Render(airspace);
                        break;
                    case Factory factory:
                        factory.Render(airspace);
                        break;
                    default:
                        building.Render(airspace);
                        break;
                }
            }

            airspace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (Drone drone in _fleet)
            {
                drone.Update(interval);
            }
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            Update(ticker.Interval);
            Render();
        }
    }
}