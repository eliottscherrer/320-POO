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

        private string[] View =
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
            Console.MoveBufferArea(X, 1, View[0].Length, View.Length, X + 1, 1);

            X++;
        }

        public void Draw()
        {
            for(int i = 0; i < View.Length; ++i)
            {
                Console.SetCursorPosition(X, i + 1);
                Console.Write(View[i]);
            }
        }
    }
}
