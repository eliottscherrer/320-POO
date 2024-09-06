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

            while (true)
            {

                plane.Update();

                Thread.Sleep(200);
            }
        }
    }
}
