using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    /// <summary>
    /// Class that specifies what the food is and has logic to spawn a new food when the previous one is eaten.
    /// If the food is eaten it also increments the score counter.
    /// </summary>
    internal class Food : GameObject
    {
        private GameWorld world;

        int följarNummer = 1;
        /// <summary>
        /// Constructor that specifies the appearance, what world it should spawn in and keep 
        /// track of the player who will eat the food.
        /// </summary>
        /// <param name="appearance">What the food will look like when rendered.</param>
        /// <param name="gameWorld">What world the food will spawn in.</param>
        /// <param name="spelare1">Which player will eat the food</param>
        public Food(char appearance, GameWorld gameWorld)
        {
            this.appearance = appearance;
            world = gameWorld;
            randomPosition();

        }
        /// <summary>
        /// Randomizes the position of the food within the world size.
        /// </summary>
        public void randomPosition()
        {   
            Random rnd = new Random();
            int height = rnd.Next(world.höjd);
            int width = rnd.Next(world.bredd);
            position = new Position(width, height);
        }

        /// <summary>
        /// Method that will check if the player/head is at the same position as the food.
        /// If it is at the position, it will randomize a new position for a new food
        /// It increase the score counter
        /// It will add a tail to the player and save it in the gameObject list
        /// It will increase the counter which dedcides what object the tail will follow.
        /// </summary>
        public override void Update()
        {
            if (position.x == world.gameObjects[1].position.x && position.y == world.gameObjects[1].position.y)
            {
                randomPosition();
                world.poäng++;
                
                Tail svans = new Tail('o', world, följarNummer);
                world.gameObjects.Add(svans);
                följarNummer++;
            }
        }
    }
}
