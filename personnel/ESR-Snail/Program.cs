using System;
using System.Collections.Generic;

namespace ESR_Snail
{
    internal class Program
    {
        static void Main()
        {
            // Init
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(50, 12);
            Console.SetBufferSize(50, 12);
            
            // Create race participants
            List<Snail> participants = new List<Snail>
            {
                new Snail("Mathis", ConsoleColor.Yellow, new Position(2, 3), ConsoleKey.W),
                new Snail("Eliott", ConsoleColor.Green, new Position(2, 6), ConsoleKey.RightArrow),
                new Snail("Théo", ConsoleColor.Magenta, new Position(2, 9), ConsoleKey.N),
            };

            // Start race
            Race race = new Race(participants, finishLineX: Console.WindowWidth - Race.FINISH_LINE_WIDTH - 1);
            race.Start();

            // Prevent console closing
            while(true)
            {
                Console.ReadKey(true);
            }
        }
    }
}
