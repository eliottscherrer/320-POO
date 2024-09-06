﻿using System;
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

            const byte PARATROOPS_COUNT_MAX = 10;
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
                        case ConsoleKey.Spacebar:
                            int spawnX = plane.X + Plane.View[0].Length / 2;
                            // Prevent crashes if we spawn the paratroop out of bounds
                            if (spawnX < Config.SCREEN_WIDTH - Para.WithoutParachute.Length && spawnX > Para.WithoutParachute.Length
                                && paratroops.Count < PARATROOPS_COUNT_MAX)
                            {
                                paratroops.Add(new Para("Blud" + paratroops.Count.ToString(), spawnX));
                                paratroops[paratroops.Count - 1].Draw();
                            }
                            
                            break;
                        default:
                            int numberPressed;
                            if(int.TryParse(cki.KeyChar.ToString(), out numberPressed))
                            {
                                // Avoid crashes
                                if(paratroops.Count > numberPressed)
                                    paratroops[numberPressed].Kill();
                            }
                            break;
                    }
                }

                foreach(Para para in paratroops)
                {
                    para.Update();
                }

                plane.Update();

                Thread.Sleep(75);
            }
        }
    }
}
