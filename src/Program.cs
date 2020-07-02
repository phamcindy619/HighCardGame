using System;
using CardGames.HighCardGames;

namespace CardGames.App {
    class Program {
        
        // Gets the user's choice, validates, and returns it.
        static char GetChoice() {
            // Get user input.
            Console.Write("Enter your choice: ");
            char choice = (char) Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine();

            // Validate user input.
            while (choice < '1' || choice > HighCardGame.MAX_CHOICES) {
                Console.WriteLine("Choice must be between 1 and " + HighCardGame.MAX_CHOICES);
                Console.Write("Enter a valid choice: ");
                choice = (char) Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine();
            }
            
            return choice;
        }

        // Driver program.
        static void Main(string[] args) {
            HighCardGame game = new HighCardGame();
            char userChoice;
            // Create game loop.
            do
            {
                HighCardGame.DisplayGameMenu();
                userChoice = GetChoice();
                
                // Execute action based on user input. If input matches the last
                // choice, then exit the game loop.
                switch (userChoice) {
                    // Start new game.
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
            } while (userChoice != HighCardGame.MAX_CHOICES);
        }
    }
}
