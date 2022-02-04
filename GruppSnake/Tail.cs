using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    /// <summary>
    /// Class that specifies how the tail will behave and be rendered.
    /// </summary>
    internal class Tail : GameObject
    {
        GameWorld world;
        int följarNummer;
        /// <summary>
        /// Creates a new tail with given apperance, the game world it will operate in and 
        /// which index to follow. Sets the position for the tail to the last index in gameObject-list
        /// </summary>
        /// <param name="appearance">What the tail will look like when rendered.</param>
        /// <param name="world">What world the tail will operate in</param>
        /// <param name="follow">What index number the tail will follow</param>
        public Tail(char appearance, GameWorld world, int follow)
        {
            this.appearance = appearance;
            this.world = world;
            följarNummer = follow;

            position = new Position(world.gameObjects[följarNummer].position.x, world.gameObjects[följarNummer].position.y);
           
        }
        /// <summary>
        /// Method that updates the position of the tail to follow it's given index-number.
        /// </summary>
        public override void Update()
        {
            position = new Position(world.gameObjects[följarNummer].position.x, world.gameObjects[följarNummer].position.y);
        }
    }
}
