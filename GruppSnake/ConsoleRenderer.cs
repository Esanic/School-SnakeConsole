using System;
using System.Collections.Generic;
using System.Text;

namespace GruppSnake
{
    /// <summary>
    /// Class that renders the score and appearance of the different game objects.
    /// </summary>
    class ConsoleRenderer
    {
        private GameWorld world;
        private BadFood badFood;
        /// <summary>
        /// Constructor that recieves the world to render in.
        /// </summary>
        /// <param name="gameWorld">What world the constructor should use to set the size of the console window.</param>
        public ConsoleRenderer(GameWorld gameWorld, BadFood badFood)
        {
            world = gameWorld;
            this.badFood = badFood;
        }

        /// <summary>
        /// Method that displays the score within the console window title
        /// Hides the cursor from the console window
        /// Render each game object in it's position and with it's appearance and color according to what object it is.
        /// </summary>
        public void Render()
        {
            Console.Title = $"Snake - Poäng: {world.score}";
            Console.CursorVisible = false;


            for (int i = world.gameObjects.Count - 1; i >= 1; i--)
            {
                Console.SetCursorPosition(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
                Console.ForegroundColor = world.gameObjects[i].color;
                Console.Write(world.gameObjects[i].appearance);
                Console.ResetColor();
            }

            if (badFood.chance == 1)
            {
                Console.SetCursorPosition(world.gameObjects[0].position.x, world.gameObjects[0].position.y);
                Console.ForegroundColor = world.gameObjects[0].color;
                Console.Write(world.gameObjects[0].appearance);
                Console.ResetColor();
            }
        }
        /// <summary>
        /// Clears the game objects appearance before the new render.
        /// </summary>
        public void Clean()
        {
            for (int i = 0; i < world.gameObjects.Count; i++)
            {
                Console.SetCursorPosition(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
                Console.Write(" ");
            }

        }
    }

}

