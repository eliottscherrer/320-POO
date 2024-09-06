using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESR_Parachutes
{
    public class Plane
    {
        public int X { get; private set; }

        public static readonly string[] View =
        {
            @" _                         ",
            @"| \                        ",
            @"|  \       ______          ",
            @"--- \_____/  |_|_\____  |  ",
            @"  \_______ --------- __>-} ",
            @"        \_____|_____/   |  "
        };

        public void Update()
        {
            for (int col = View[0].Length - 1; col >= 0; --col)
            {
                Console.MoveBufferArea((X + col) % Config.SCREEN_WIDTH, 0, 1, View.Length, (X + col + 1) % Config.SCREEN_WIDTH, 0);
            }

            X = (X + 1) % Config.SCREEN_WIDTH;
        }

        public void Draw()
        {
            for (int i = 0; i < View.Length; ++i)
            {
                Console.SetCursorPosition(X, i);
                Console.Write(View[i]);
            }
        }
    }
}
