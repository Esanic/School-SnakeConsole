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
        public static void Loop(int difficulty)
        {

            // Initializing the game
            int frameRate = difficulty*2;

            //Instanciating a GameWorld and a ConsoleRenderer
            GameWorld world = new GameWorld(50,20);
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            //Instanciating the player
            Player spelare = new Player('0', world);
            //Instanciating the food
            Food mat = new Food('#', world, difficulty);
            
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

        static void Main(string[] args)
        {
            // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
            bool running = true;
            
            Console.WriteLine("Välkommen till Snake!");
            Console.WriteLine("---------------------");
            while (running == true)
            {
                string menuChoice;
                Console.WriteLine("1. Spela");
                Console.WriteLine("2. Instruktioner");
                Console.WriteLine("3. Avsluta");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        bool runningChoiceOne = true;
                        while (runningChoiceOne == true)
                        {
                            Console.WriteLine("Vänligen ange en svårighetsnivå. 1-9");
                            string strDifficulty = Console.ReadLine();

                            if (Regex.IsMatch(strDifficulty, @"\b[1-9]\b"))
                            {
                                int difficulty = int.Parse(strDifficulty);
                                Console.Clear();
                                Loop(difficulty);
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Du angav inte en siffra mellan 1-9. Försök igen.");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        break;
                   case "2":
                        TypeOut instructions = new TypeOut();
                        instructions.Instructions();
                        break;
                   case "3":
                        Console.Clear();
                        running = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Du angav inte ett giltigt menyval. Försök igen.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
