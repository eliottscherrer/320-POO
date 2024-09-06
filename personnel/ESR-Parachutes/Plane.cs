using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESR_Parachutes
{
    public class Plane
    {
        public int x { get; private set; }

        private string[] view =
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
            Console.MoveBufferArea(x, 1, view[0].Length, view.Length, x + 1, 1);

            x++;
        }

        public void Draw()
        {
            for(int i = 0; i < view.Length; ++i)
            {
                Console.SetCursorPosition(x, i + 1);
                Console.Write(view[i]);
            }
        }
    }
}
