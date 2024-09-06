using System;
using System.Collections.Generic;

namespace ESR_Snail
{
    internal class Program
    {
        static void Main()
        {
            const int DISTANCE = 3; // Distance between each snail

            // Init
            Console.Clear();
            Console.CursorVisible = false;

            // Prevent console closing
            while (true)
            {
                // Create race participants
                List<Snail> participants = new List<Snail>
                {
                    new Snail("Mathis", ConsoleColor.Yellow, new Position(2, DISTANCE), ConsoleKey.W),
                    new Snail("Eliott", ConsoleColor.Green, new Position(2, DISTANCE * 2), ConsoleKey.LeftArrow),
                    new Snail("Théo", ConsoleColor.Magenta, new Position(2, DISTANCE * 3), ConsoleKey.N),
                    new Snail("Eithan", ConsoleColor.Cyan, new Position(2, DISTANCE * 4), ConsoleKey.NumPad3),
                    new Snail("Ethan", ConsoleColor.Red, new Position(2, DISTANCE * 5), ConsoleKey.Tab),
                };

                Console.SetWindowSize(50, (participants.Count + 1) * DISTANCE);
                Console.SetBufferSize(50, (participants.Count + 1) * DISTANCE);

                Console.Clear();

                // Start race
                Race race = new Race(participants, finishLineX: Console.WindowWidth - Race.FINISH_LINE_WIDTH - 1);
                race.Start();

                participants.Clear();

                Console.ReadKey(true);
            }
        }
    }
}
