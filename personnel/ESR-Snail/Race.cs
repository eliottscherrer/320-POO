using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ESR_Snail
{
    public class Race
    {
        private readonly Random Rand;

        private readonly List<Snail> Participants;
        private readonly int FinishLineX;
        public const int FINISH_LINE_WIDTH = 5;

        public Snail Winner { get; private set; }

        public Race(List<Snail> participants, int finishLineX)
        {
            Participants = participants;
            FinishLineX = finishLineX;

            Rand = new Random();
        }

        public void Start()
        {
            DrawFinishLine();
            foreach (var participant in Participants)
            {
                participant.Draw();
            }

            Countdown();

            // Clear keyboard buffer before starting the race
            // To avoid all the keypresses done during the countdown to be accepted
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            while (!IsFinished())
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    foreach (Snail participant in Participants)
                    {
                        if (participant.MoveKey == key)
                        {
                            participant.Move();
                            CheckWinner(participant);
                        }
                    }
                }

                Thread.Sleep(10);
            }

            ShowWinner();
            Thread.Sleep(3000);
        }

        private void Countdown()
        {
            const int PADDING = 2;
            int countdownSeconds = 3;
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            string message = "Ready ?";
            int messageLength = message.Length + PADDING * 2;

            // Center frame
            int left = (windowWidth - messageLength) / 2;
            int top = windowHeight / 2 - 2;

            // Chars
            char topLeft = '╔',
                topRight = '╗',
                bottomLeft = '╚',
                bottomRight = '╝',
                horizontal = '═',
                vertical = '║';

            // Draw frame
            Console.SetCursorPosition(left, top);
            Console.Write(topLeft + new string(horizontal, messageLength - PADDING) + topRight);

            Console.SetCursorPosition(left, top + 1);
            Console.Write(vertical + new string(' ', messageLength - PADDING) + vertical);

            Console.SetCursorPosition(left, top + 2);
            Console.Write(vertical + new string(' ', messageLength - PADDING) + vertical);

            Console.SetCursorPosition(left, top + 3);
            Console.Write(bottomLeft + new string(horizontal, messageLength - PADDING) + bottomRight);

            // Display "Prêt?"
            Console.SetCursorPosition(left + PADDING, top + 1);
            Console.Write(message);

            // Countdown
            for (int i = countdownSeconds; i > 0; i--)
            {
                Console.SetCursorPosition(left + messageLength / 2, top + 2);

                switch (i)
                {
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }

                Console.Write(i);

                // Wait for keypresses then start the countdown
                if (i == countdownSeconds)
                    Console.ReadKey(true);

                Thread.Sleep(1000);
                Console.ResetColor();
            }

            // Display "GO!"
            Console.SetCursorPosition(left + PADDING, top + 2);
            Console.Write("  GO!  ");
            Thread.Sleep(1000);

            // Clear frame
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(new string(' ', messageLength));
            }
        }

        private void CheckWinner(Snail participant)
        {
            if (participant.Pos.x + Snail.SNAIL_SPRITE.Length + 1 > FinishLineX)
            {
                Winner = participant;
            }
        }

        private void DrawFinishLine()
        {
            const int PADDING = 2;

            int finishLineStartY = Participants.First().Pos.y - PADDING;
            int distanceFirstToLast = Participants.Last().Pos.y - Participants.First().Pos.y;
            int finishLineLength = distanceFirstToLast + PADDING * 2 + 1;

            for (int i = 0; i < finishLineLength; i++)
            {
                Console.SetCursorPosition(FinishLineX, finishLineStartY + i);

                for (int j = 0; j < FINISH_LINE_WIDTH; j++)
                {
                    bool isBlack = (i + j) % 2 != 0;
                    Console.BackgroundColor = isBlack ? ConsoleColor.Black : ConsoleColor.White;
                    Console.Write(' ');
                }
            }

            Console.ResetColor();
        }

        public void ShowWinner()
        {
            const int PADDING = 2;

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            string winnerName = Winner.Name;
            string message = $"{winnerName} a gagné!";
            int messageLength = message.Length + PADDING * 2; // +4 pour les bordures gauche et droite

            // Center frame
            int left = (windowWidth - messageLength) / 2;
            int top = windowHeight / 2 - 1;

            // Chars
            char topLeft = '╔',
                topRight = '╗',
                bottomLeft = '╚',
                bottomRight = '╝',
                horizontal = '═',
                vertical = '║';

            // Frame top
            Console.SetCursorPosition(left, top);
            Console.Write(topLeft + new string(horizontal, messageLength - PADDING) + topRight);

            // Frame middle
            Console.SetCursorPosition(left, top + 1);
            Console.Write(vertical);
            Console.ForegroundColor = Winner.Color;
            Console.Write($" {winnerName} ");
            Console.ResetColor();
            Console.Write("a gagné! ");
            Console.Write(vertical);

            // Frame bottom
            Console.SetCursorPosition(left, top + PADDING);
            Console.Write(bottomLeft + new string(horizontal, messageLength - PADDING) + bottomRight);

            Console.ResetColor();
        }

        public bool IsFinished() => Winner != null;
    }
}
