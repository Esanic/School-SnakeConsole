using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    /// <summary>
    /// Class that handles the game over screen.
    /// </summary>
    internal class TypeOut
    {
        /// <summary>
        /// Method that types out the Game Over screen with the players score upon game over.
        /// </summary>
        /// <param name="world">The world that the score is counted in.</param>
        public void Gameover(GameWorld world)
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
            Console.WriteLine($"Du fick {world.score} poäng");
        }
        /// <summary>
        /// Method that types out the instructions for the game
        /// </summary>
        public void Instructions()
        {
            Console.Clear();
            Console.WriteLine("Instruktioner");
            Console.WriteLine("-------------");
            Console.Write("UPP:");
            Console.SetCursorPosition(10, 2);
            Console.Write("W eller piltangent upp");
            Console.WriteLine("");
            Console.WriteLine("NER:");
            Console.SetCursorPosition(10, 3);
            Console.Write("S eller piltangent ner");
            Console.WriteLine("");
            Console.WriteLine("VÄNSTER:");
            Console.SetCursorPosition(10, 4);
            Console.Write("A eller piltangent vänster");
            Console.WriteLine("");
            Console.WriteLine("HÖGER:");
            Console.SetCursorPosition(10, 5);
            Console.Write("D eller piltangent höger");
            Console.WriteLine("");
            Console.WriteLine("AVSLUTA:");
            Console.SetCursorPosition(10, 6);
            Console.Write("Q");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Tryck Enter för att gå tillbaka...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
