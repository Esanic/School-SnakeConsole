using System;
using System.Collections.Generic;
using System.Text;

namespace GruppSnake
{
    abstract class GameObject
    {
        public Position position;
        public char appearance;

        public abstract void Update();
    }
}
