using System;
using System.Threading;

namespace GruppSnake
{
    class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
        /// </summary>
        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

        static void Loop()
        {
            // Initialisera spelet
            const int frameRate = 5;
            GameWorld world = new GameWorld(50,20);
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
            
            Player spelare = new Player('O', world);
            Food mat = new Food('#', world, spelare);
            
            world.gameObjects.Add(mat);
            world.gameObjects.Add(spelare);

            // Huvudloopen
            bool running = true;
            while (running)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren
                ConsoleKey key = ReadKeyIfExists();
                switch (key)
                {
                    case ConsoleKey.Q:
                        running = false;
                        break;
                    case ConsoleKey.P:
                        spelare.direction = Player.Direction.Pause;
                        break;
                    //up
                    case ConsoleKey.W:
                        spelare.direction = Player.Direction.Up;
                        break;
                    case ConsoleKey.UpArrow:
                        spelare.direction = Player.Direction.Up;
                        break;
                    //down
                    case ConsoleKey.S:
                        spelare.direction = Player.Direction.Down;
                        break;
                    case ConsoleKey.DownArrow:
                        spelare.direction = Player.Direction.Down;
                        break;
                    //left
                    case ConsoleKey.A:
                        spelare.direction = Player.Direction.Left;
                        break;
                    case ConsoleKey.LeftArrow:
                        spelare.direction = Player.Direction.Left;
                        break;
                    //right
                    case ConsoleKey.D:
                        spelare.direction = Player.Direction.Right;
                        break;
                    case ConsoleKey.RightArrow:
                        spelare.direction = Player.Direction.Right;
                        break;
                }

                // Uppdatera världen och rendera om
                renderer.Clean();
                world.Update();
                //renderer.RenderTail();
                renderer.Render();

                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
            }
        }

        static void Main(string[] args)
        {
            // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
            Loop();
        }
    }
}
