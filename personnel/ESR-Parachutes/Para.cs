using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ESR_Parachutes
{
    public enum ParaState
    {
        FREE_FALL,
        FLOATING,
        LANDED,
        DEAD
    }

    internal class Para
    {
        public int X, Y;
        public ParaState State { get; private set; }

        public string[] Sprite
        {
            get
            {
                switch (State)
                {
                    case ParaState.FREE_FALL:
                    case ParaState.LANDED:
                        return WithoutParachute;
                    case ParaState.FLOATING:
                        return WithParachute;
                    case ParaState.DEAD:
                        return DeadBody;
                    default:
                        return new string[] { "ERROR" };
                }
            }
        }

        private int Speed
        {
            get
            {
                switch (State)
                {
                    case ParaState.FREE_FALL:
                        return 3;
                    case ParaState.FLOATING:
                        return 1;
                    case ParaState.LANDED:
                    case ParaState.DEAD:
                        return 0;

                    default:
                        return 0;
                }
            }
        }

        public string[] WithoutParachute =
        {
            @"PLACEHOLDERNAME",
            @"  o  ",
            @" /░\ ",
            @" / \ ",
        };

        public string[] WithParachute =
        {
            @"PLACEHOLDERNAME",
            @" ___ ",
            @"/|||\",
            @"\   /",
            @" \o/ ",
            @"  ░  ",
            @" / \ ",
        };

        public string[] DeadBody =
        {
            @"PLACEHOLDERNAME",
            @">---o"
        };

        public string Name { get; private set; }

        public Para(string name, int x)
        {
            Name = name;
            X = x;
            Y = Plane.View.Length;

            WithParachute[0] = WithoutParachute[0] = DeadBody[0] = Name;
        }

        public void Update()
        {
            if (State == ParaState.DEAD)
                return;
            // Land
            else if (Y + Sprite.Length >= Config.SCREEN_HEIGHT)
            {
                State = ParaState.LANDED;
                ClearSprite();
                Draw(WithParachute.Length - WithoutParachute.Length);
                return;
            }
            // Deploy parachute
            else if (Y > Config.SCREEN_HEIGHT / 2 && State == ParaState.FREE_FALL)
            {
                State = ParaState.FLOATING;
                Draw();
                return;
            }

            // Move
            Console.MoveBufferArea(X, Y, Sprite[Sprite.Length - 1].Length, Sprite.Length, X, Y + Speed);
            Y += Speed;
        }

        public void Draw(int offset = 0)
        {
            for (int i = 0; i < Sprite.Length; ++i)
            {
                Console.SetCursorPosition(X, Y + i + offset);
                Console.Write(Sprite[i]);
            }
        }

        private void ClearSprite()
        {
            for (int i = 0; i < Sprite.Length; ++i)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(new string(' ', Sprite[i].Length));
            }
        }

        public void Kill()
        {
            if (State == ParaState.LANDED || State == ParaState.DEAD)
                return;

            const char BLOOD_SPLATTER = '*';

            // Make the paratroop go to the ground
            ClearSprite();
            State = ParaState.DEAD;
            Draw();
            Console.MoveBufferArea(X, Y, Sprite[Sprite.Length - 1].Length, Sprite.Length, X, Config.SCREEN_HEIGHT - Sprite.Length);
            Y = Config.SCREEN_HEIGHT - Sprite.Length;

            List<(int, int)> bloodCoordinates = new List<(int, int)>
            {
                (X - 1, Y + 1),
                (X + 5, Y + 1),
                (X + 6, Y + 1),
            };

            // Draw blood stains
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var (bloodX, bloodY) in bloodCoordinates)
            {
                if (bloodX >= 0 && bloodX < Console.WindowWidth && bloodY >= 0 && bloodY < Console.WindowHeight)
                {
                    Console.SetCursorPosition(bloodX, bloodY);
                    Console.Write(BLOOD_SPLATTER);
                }
            }
            Console.ResetColor();
        }
    }
}
