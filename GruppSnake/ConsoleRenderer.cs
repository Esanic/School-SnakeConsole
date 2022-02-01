using System;
using System.Collections.Generic;
using System.Text;

namespace GruppSnake
{
    class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // TODO Konfigurera Console-fönstret enligt världens storlek

            world = gameWorld;
            Console.SetWindowSize(world.bredd, world.höjd);
        }

        public void Render()
        {
            // TODO Rendera spelvärlden (och poängräkningen)
            Console.SetCursorPosition(0, 0);
            Console.Write(world.gameObjects[0].appearance);
            // Använd Console.SetCursorPosition(int x, int y) and Console.Write(char)
        }
    }
}
