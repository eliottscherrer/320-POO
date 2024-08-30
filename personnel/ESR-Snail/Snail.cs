using System;

namespace ESR_Snail
{
    public class Snail
    {
        public const string SNAIL_SPRITE = "_@_ö";
        public Position Pos { get; private set; }
        public ConsoleColor Color { get; private set; }
        public readonly string Name;
        public ConsoleKey MoveKey { get; private set; }

        public Snail(string name, ConsoleColor color, Position position, ConsoleKey moveKey)
        {
            Pos = position;
            Color = color;
            Name = name;
            MoveKey = moveKey;
            Draw();
        }

        private void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Pos.x, Pos.y);
            Console.Write(SNAIL_SPRITE);
        }

        public void Move()
        {
            Pos = new Position(Pos.x + 1, Pos.y);
            Console.MoveBufferArea(Pos.x - 1, Pos.y, SNAIL_SPRITE.Length, 1, Pos.x, Pos.y);
        }
    }
}
