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
            GameWorld world = new GameWorld(100,40);
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
            Player spelare = new Player('O', world);
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
                    case ConsoleKey.W:
                        spelare.direction = Player.Direction.Up;
                        break;
                    case ConsoleKey.S:
                        spelare.direction = Player.Direction.Down;
                        break;
                    case ConsoleKey.A:
                        spelare.direction = Player.Direction.Left;
                        break;
                    case ConsoleKey.D:
                        spelare.direction = Player.Direction.Right;
                        break;

                    // TODO Lägg till logik för andra knapptryckningar
                    // ...
                }

                // Uppdatera världen och rendera om
                renderer.rensa();
                world.Update();
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
