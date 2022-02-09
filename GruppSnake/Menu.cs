using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GruppSnake
{
    internal class Menu
    {
        /// <summary>
        /// Method that handles the Start menu
        /// </summary>
        public void StartMenu(int windowWidth, int windowHeight)
        {
            bool running = true;

            Console.WriteLine("Välkommen till Snake!");
            Console.WriteLine("---------------------");
            while (running == true)
            {
                string menuChoice;
                Console.WriteLine("1. Spela");
                Console.WriteLine("2. Instruktioner");
                Console.WriteLine("3. Avsluta");
                Console.WriteLine("");
                Console.Write("Ditt svar: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        bool runningChoiceOne = true;
                        while (runningChoiceOne == true)
                        {
                            Console.WriteLine("Vänligen ange en svårighetsnivå. 1-9");
                            Console.WriteLine("");
                            Console.Write("Ditt svar: ");
                            string strDifficulty = Console.ReadLine();

                            if (Regex.IsMatch(strDifficulty, @"\b[1-9]\b"))
                            {
                                int difficulty = int.Parse(strDifficulty);
                                Console.Clear();
                                Program.Loop(difficulty, windowWidth, windowHeight);
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                Console.Title = "Snake";
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Du angav inte en siffra mellan 1-9. Försök igen.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        break;
                    case "2":
                        TypeOut Instructions = new TypeOut();
                        Instructions.Instructions();
                        break;
                    case "3":
                        Console.Clear();
                        running = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Du angav inte ett giltigt menyval. Försök igen.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
