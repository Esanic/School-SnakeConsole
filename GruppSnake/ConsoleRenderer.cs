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
            //Console.SetBufferSize(world.bredd, world.höjd);
        }

        public void Render()
        {
            // TODO Rendera spelvärlden och poängräkningen)
            Console.Title = $"Snake - Poäng: {world.poäng}";
            Console.CursorVisible = false;
            //for (int i = 0; i < world.gameObjects.Count; i++)
            //{
            //    Console.SetCursorPosition(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
            //    Console.Write(world.gameObjects[i].appearance);
            //}
            for (int i = world.gameObjects.Count - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
                Console.Write(world.gameObjects[i].appearance);
            }
        }

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

