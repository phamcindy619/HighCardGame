using System;
using CardGame.HighCardGames;

namespace CardGame.App {
    class Program {
        

        // Driver program.
        static void Main(string[] args) {
            HighCardGame game = new HighCardGame();
            char userChoice;
            // Create game loop.
            do
            {
                HighCardGame.DisplayGameMenu();
                userChoice = HighCardGame.GetChoice();
                
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
