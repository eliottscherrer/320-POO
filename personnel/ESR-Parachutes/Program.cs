using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ESR_Parachutes
{
    public static class Program
    {
        const byte PARATROOPS_MAX_COUNT = 10;
        const byte CYCLE_DURATION = 75;

        static void Main(string[] args)
        {
            InitializeConsole();
            Plane plane = new Plane();
            plane.Draw();

            List<Para> paratroops = new List<Para>();

            while (true)
            {
                HandleInput(plane, paratroops);
                UpdateEntities(paratroops, plane);
                Thread.Sleep(CYCLE_DURATION);
            }
        }

        private static void InitializeConsole()
        {
            Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
            Console.CursorVisible = false;
        }

        private static void HandleInput(Plane plane, List<Para> paratroops)
        {
            if (!Console.KeyAvailable) return;

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Spacebar:
                    SpawnParatroop(plane, paratroops);
                    break;
                default:
                    HandleParatroopKill(paratroops, keyInfo);
                    break;
            }
        }

        private static void SpawnParatroop(Plane plane, List<Para> paratroops)
        {
            int spawnX = plane.X + Plane.View[0].Length / 2;
            bool isValidSpawn = spawnX > paratroops.FirstOrDefault()?.WithoutParachute.Length
                                && spawnX < Config.SCREEN_WIDTH - paratroops.FirstOrDefault()?.WithoutParachute.Length
                                && paratroops.Count < PARATROOPS_MAX_COUNT;

            if (isValidSpawn || paratroops.Count == 0)
            {
                string name = $"Blud{paratroops.Count}";
                Para newPara = new Para(name, spawnX);
                paratroops.Add(newPara);
                newPara.Draw();
            }
        }

        private static void HandleParatroopKill(List<Para> paratroops, ConsoleKeyInfo keyInfo)
        {
            if (int.TryParse(keyInfo.KeyChar.ToString(), out int index) && index < paratroops.Count)
            {
                paratroops[index].Kill();
            }
        }

        private static void UpdateEntities(List<Para> paratroops, Plane plane)
        {
            foreach (Para para in paratroops)
            {
                para.Update();
            }

            plane.Update();
        }
    }
}
