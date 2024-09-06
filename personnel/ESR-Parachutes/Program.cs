using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ESR_Parachutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);

            Console.CursorVisible = false;

            Plane plane = new Plane();
            plane.Draw();

            List<Para> paratroops = new List<Para>();

            while (true)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    switch(cki.Key)
                    {
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        case ConsoleKey.I:
                            paratroops.Add(new Para("Bob", plane.X + Plane.View[0].Length / 2));
                            paratroops[paratroops.Count - 1].Draw();
                            break;
                    }
                }

                foreach(Para para in paratroops)
                {
                    para.Update();
                }

                plane.Update();

                Thread.Sleep(50);
            }
        }
    }
}
