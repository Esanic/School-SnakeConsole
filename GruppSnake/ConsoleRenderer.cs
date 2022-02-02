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
            Console.SetBufferSize(world.bredd, world.höjd);
        }

        public void Render()
        {
            // TODO Rendera spelvärlden och poängräkningen)
            Console.Title = $"Snake - Poäng: {world.poäng}";
            Console.CursorVisible = false;
            for(int i = 0; i < world.gameObjects.Count; i++)
            {
                Console.SetCursorPosition(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
                Console.Write(world.gameObjects[i].appearance);
            }
            //Console.SetCursorPosition(world.gameObjects[0].position.x, world.gameObjects[0].position.y);
            //Console.Write(world.gameObjects[0].appearance);
            //Console.SetCursorPosition(world.gameObjects[1].position.x, world.gameObjects[1].position.y);
            //Console.Write(world.gameObjects[1].appearance);
            // Använd Console.SetCursorPosition(int x, int y) and Console.Write(char)
        }
        public void rensa()
        {
            Console.SetCursorPosition(world.gameObjects[0].position.x, world.gameObjects[0].position.y);
            Console.Write(" ");
           
        }
    }

}

