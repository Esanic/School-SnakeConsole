using System;
using System.Collections.Generic;
using System.Text;

namespace GruppSnake
{
    abstract class GameObject
    {
        public Position position;
        public char appearance;
        public enum Direction
        {
            Right,
            Left,
            Up,
            Down,
            Pause
        }

        public Direction direction;

        public abstract void Update();
    }
}
