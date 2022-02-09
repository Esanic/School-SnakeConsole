using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    internal class BadFood : GameObject
    {
        private GameWorld world;
        FollowCount followCount;
        int difficulty;
        public int chance;

        /// <summary>
        /// Constructor that specifies the appearance, what world it should spawn in and keep 
        /// track of the player who will eat the food.
        /// </summary>
        /// <param name="appearance">What the food will look like when rendered.</param>
        /// <param name="gameWorld">What world the food will spawn in.</param>
        /// <param name="difficulty">What difficulty the user chose.</param>
        /// <param name="color">What color the object will be rendered with</param>
        public BadFood(char appearance, GameWorld gameWorld, int difficulty, ConsoleColor color, FollowCount followCount)
        {
            this.appearance = appearance;
            world = gameWorld;
            this.difficulty = difficulty;
            this.color = color;
            this.followCount = followCount; 
            RandomPosition();
            this.chance = ChanceOfAppearance();

        }
        /// <summary>
        /// Randomizes the position of the food within the world size.
        /// </summary>
        public void RandomPosition()
        {
            Random rnd = new Random();
            int height = rnd.Next(world.height);
            int width = rnd.Next(world.width);
            position = new Position(width, height);
        }

        public int ChanceOfAppearance()
        {
            Random randomChance = new Random();
            int chanceOfAppearance = randomChance.Next(1, 5);
            return chanceOfAppearance;
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
  
            if (position.x == world.gameObjects[2].position.x && position.y == world.gameObjects[2].position.y)
            {
                this.chance = ChanceOfAppearance();
                RandomPosition();
                world.score -= difficulty;

                Tail tail = new Tail('o', world, followCount.followCounter, ConsoleColor.Yellow);
                world.gameObjects.Add(tail);
                followCount.followCounter++;
            }
            
        }
    }
}


