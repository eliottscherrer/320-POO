namespace Drones.Helpers
{
    // Outils pour écrire du texte dans un environnement graphique
    internal static class TextHelpers
    {
        private const string DRAW_FONT_NAME = "Arial";
        private const int DRAW_FONT_SIZE = 10;
        public static readonly Font drawFont = new(DRAW_FONT_NAME, DRAW_FONT_SIZE);

        private readonly static Color WRITE_BRUSH_COLOR = Color.Black;
        public static readonly SolidBrush writingBrush = new(WRITE_BRUSH_COLOR);
    }
}
