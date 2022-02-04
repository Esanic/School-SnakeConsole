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
       
        /// <summary>
        /// Method that starts the game and have a loop to check if the player either quit or has lost.
        /// </summary>
        static void Loop()
        {
            
            // Initializing the game
            const int frameRate = 10;
            
            //Instanciating a GameWorld and a ConsoleRenderer
            GameWorld world = new GameWorld(50,20);
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            //Instanciating the player
            Player spelare = new Player('0', world);
            //Instanciating the food
            Food mat = new Food('#', world);
            
            //Adds the objects to the gameObjects list
            world.gameObjects.Add(mat);
            world.gameObjects.Add(spelare);

            // Mainloop to check if the game is still running
            bool running = true;
            while (running)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Handles the key presses from the user
                ConsoleKey key = ReadKeyIfExists();
                switch (key)
                {
                    //quit
                    case ConsoleKey.Q:
                        running = false;
                        break;
                    //pause
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

                // Cleans the world, checks if the head has collided
                // Updates the world and then render everything again
                renderer.Clean();
                spelare.CollisionCheck();
                if (spelare.CollisionCheck() == false)
                {
                    world.gameObjects.Clear();
                    Console.Clear();
                    GameOver();
                    Console.ReadLine();
                    running = false;
                }
                world.Update();
                renderer.Render();
                

                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
                
                // Method that types out game over and display the users score
                void GameOver()
                {
                    Console.SetCursorPosition(10, 3);
                    Console.WriteLine($"  _____          __  __ ______ ");
                    Console.SetCursorPosition(10, 4);
                    Console.WriteLine($" / ____|   /\\   |  \\/  |  ____|");
                    Console.SetCursorPosition(10, 5);
                    Console.WriteLine($"| |  __   /  \\  | \\  / | |__   ");
                    Console.SetCursorPosition(10, 6);
                    Console.WriteLine($"| | |_ | / /\\ \\ | |\\/| |  __|  ");
                    Console.SetCursorPosition(10, 7);
                    Console.WriteLine($"| |__| |/ ____ \\| |  | | |____ ");
                    Console.SetCursorPosition(10, 8);
                    Console.WriteLine($" \\_____/_/    \\_\\_|  |_|______|");
                    Console.SetCursorPosition(10, 9);
                    Console.WriteLine($"  ______      ________ _____  ");
                    Console.SetCursorPosition(10, 10);
                    Console.WriteLine($" / __ \\ \\    / /  ____|  __ \\ ");
                    Console.SetCursorPosition(10, 11);
                    Console.WriteLine($"| |  | \\ \\  / /| |__  | |__) |");
                    Console.SetCursorPosition(10, 12);
                    Console.WriteLine($"| |  | |\\ \\/ / |  __| |  _  / ");
                    Console.SetCursorPosition(10, 13);
                    Console.WriteLine($"| |__| | \\  /  | |____| | \\ \\ ");
                    Console.SetCursorPosition(10, 14);
                    Console.WriteLine($" \\____/   \\/   |______|_|  \\_\\");
                    Console.SetCursorPosition(10, 15);
                    Console.WriteLine($"");
                    Console.SetCursorPosition(18, 16);
                    Console.WriteLine($"Du fick {world.poäng} poäng");
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
