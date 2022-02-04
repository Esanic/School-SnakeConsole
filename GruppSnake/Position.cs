using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    /// <summary>
    /// Creates a positioning ability for the game objects in order to be rendered in the given area/world.
    /// </summary>
    public class Position
    {
        public int x;
        public int y;

        /// <summary>
        /// Creates the positioning of an object.
        /// </summary>
        /// <param name="bredd">Position on the vertical axis</param>
        /// <param name="höjd">Position on the hortizontal axis</param>
        public Position(int bredd, int höjd)
        {
            this.x = bredd;
            this.y = höjd;
        }
    }
}
