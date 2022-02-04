using System;
using System.Collections.Generic;
using System.Text;

namespace GruppSnake
{
    /// <summary>
    /// Class that handles the console window size and also renders the score and appearance of the different game objects.
    /// </summary>
    class ConsoleRenderer
    {
        private GameWorld world;
        /// <summary>
        /// Sets the console window size according to the given world size.
        /// </summary>
        /// <param name="gameWorld">What world the constructor should use to set the size of the console window.</param>
        public ConsoleRenderer(GameWorld gameWorld)
        {
            world = gameWorld;
            Console.SetWindowSize(world.bredd, world.höjd);
            Console.SetBufferSize(world.bredd, world.höjd);
        }

        /// <summary>
        /// Method that displays the score within the console window title
        /// Hides the cursor from the console window
        /// Render each game object in it's position and with it's appearance
        /// </summary>
        public void Render()
        {
            Console.Title = $"Snake - Poäng: {world.poäng}";
            Console.CursorVisible = false;

            for (int i = world.gameObjects.Count - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
                if(world.gameObjects[i] is Food)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(world.gameObjects[i].appearance);
                    Console.ResetColor();
                }
                if (world.gameObjects[i] is Player)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(world.gameObjects[i].appearance);
                    Console.ResetColor();
                }
                if (world.gameObjects[i] is Tail)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(world.gameObjects[i].appearance);
                    Console.ResetColor();
                }
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

