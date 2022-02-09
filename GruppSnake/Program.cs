using System;
using System.Threading;
using System.Text.RegularExpressions;

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
        public static void Loop(int difficulty, int windowWidth, int windowHeight)
        {

            // Initializing the game
            int frameRate = difficulty*2;

            //Instanciating a GameWorld and a ConsoleRenderer
            GameWorld world = new GameWorld(windowWidth-1,windowHeight);
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            //Instanciating the player
            Player player = new Player('0', world, ConsoleColor.DarkGreen);
            //Instanciating the food
            Food food = new Food('#', world, difficulty, ConsoleColor.DarkRed);
            
            //Adds the objects to the gameObjects list
            world.gameObjects.Add(food);
            world.gameObjects.Add(player);

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
                    //up
                    case ConsoleKey.W:
                        player.direction = Player.Direction.Up;
                        break;
                    case ConsoleKey.UpArrow:
                        player.direction = Player.Direction.Up;
                        break;
                    //down
                    case ConsoleKey.S:
                        player.direction = Player.Direction.Down;
                        break;
                    case ConsoleKey.DownArrow:
                        player.direction = Player.Direction.Down;
                        break;
                    //left
                    case ConsoleKey.A:
                        player.direction = Player.Direction.Left;
                        break;
                    case ConsoleKey.LeftArrow:
                        player.direction = Player.Direction.Left;
                        break;
                    //right
                    case ConsoleKey.D:
                        player.direction = Player.Direction.Right;
                        break;
                    case ConsoleKey.RightArrow:
                        player.direction = Player.Direction.Right;
                        break;
                }

                // Cleans the world, checks if the head has collided
                // Updates the world and then render everything again
                renderer.Clean();
                player.CollisionCheck();
                if (player.CollisionCheck() == false)
                {
                    world.gameObjects.Clear();
                    Console.Clear();
                    TypeOut Gameover = new TypeOut();
                    Gameover.Gameover(world);
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
            }
        }
        /// <summary>
        /// Main method that will set the window size and enter the menu.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WindowSize windowSize = new WindowSize(51, 20);
            Console.Title = "Snake";
            Console.SetWindowSize(windowSize.width, windowSize.height);
            Console.SetBufferSize(windowSize.width, windowSize.height);

            Menu startMenu = new Menu();
            startMenu.StartMenu(windowSize.width, windowSize.height);
            }
        }
    }

