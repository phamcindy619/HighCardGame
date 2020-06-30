using System;
using HighCardGame.CardSystems;

namespace HighCardGame.App {
    class Program {
        // Maximum number of menu choices
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

        // Gets the user's choice, validates, and returns it
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

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine();
                
                // Execute action based on user input
                switch (userChoice) {
                    // Start new game
                    case '1':
                        game.DealCards();
                        game.GetWinner();
                        game.RestartGame();
                        break;
                }
            } while (userChoice != MAX_CHOICES);
            
        }
    }
}
