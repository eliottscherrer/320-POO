using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESR_Parachutes
{
    public enum ParaState
    {
        FREE_FALL,
        FLOATING,
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
                        return WithoutParachute;
                    case ParaState.FLOATING:
                        return WithParachute;
                    default:
                        return new string[] { "ERROR" };
                }
            }
        }

        private string[] WithoutParachute =
       {
            @"  o  ",
            @" /░\ ",
            @" / \ ",
        };

        private string[] WithParachute =
        {
             @" ___ ",
             @"/|||\",
             @"\   /",
             @" \o/ ",
             @"  ░  ",
             @" / \ ",
        };

        public string Name { get; private set; }

        public Para(string name, int x)
        {
            Name = name;
            X = x;
            Y = Plane.View.Length;
        }

        public void Update()
        {
            Console.MoveBufferArea(X, Y, Sprite[0].Length, Sprite.Length, X, Y + 1);

            Y++;
        }

        public void Draw()
        {
            for (int i = 0; i < Sprite.Length; ++i)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(Sprite[i]);
            }
        }
    }
}
