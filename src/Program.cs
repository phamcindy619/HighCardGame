using System;
using HighCardGame.CardSystems;

namespace HighCardGame.App {
    class Program {
        // Maximum number of menu options for user to select from
        const char MAX_CHOICES = '2';

        // Display all menu options for High Card game
        static void DisplayGameMenu() {
            Console.WriteLine();
            Console.WriteLine("    MAIN MENU");
            Console.WriteLine("===================");
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Quit");
            Console.WriteLine();
        }

        // Get the user's choice from input, validates, and returns it
        static char GetChoice() {
            // Get user input
            Console.Write("Enter your choice: ");
            char choice = (char) Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine();

            // Validate input
            while (choice < '1' || choice > MAX_CHOICES) {
                Console.WriteLine("Choice must be between 1 and " + MAX_CHOICES);
                Console.Write("Enter a valid choice: ");
                choice = (char) Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine();
            }
            
            return choice;
        }

        // Driver program
        static void Main(string[] args) {
            CardSystem game = new CardSystem();
            char userChoice;
            // Create game loop
            do
            {
                DisplayGameMenu();
                userChoice = GetChoice();
                
                // Execute action based on user input
                switch (userChoice) {
                    // Start new game
                    case '1':
                        Console.WriteLine("Press any key to deal cards.");
                        Console.ReadKey();
                        Console.WriteLine();

                        game.DealCards();
                        game.ShowCards();
                        game.ShowWinner();
                        game.RestartGame();
                        break;
                }
            } while (userChoice != MAX_CHOICES);
            
        }
    }
}
