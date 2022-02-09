using System;
using System.Collections.Generic;
using System.Text;

namespace GruppSnake
{
    /// <summary>
    /// Interface abstract class that is the base for all the objects that 
    /// will be rendered within the game.
    /// </summary>
    abstract class GameObject
    {
        public Position position;
        public char appearance;
        public ConsoleColor color;

        public abstract void Update();
    }
}
