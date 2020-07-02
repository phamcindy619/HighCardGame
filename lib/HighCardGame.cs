using System;
using System.Collections.Generic;
using CardGames.CardSystems;
using CardGames.Cards;
using CardGames.Players;


namespace CardGames.HighCardGames {
    /// <summary>
    /// The main HighCardGame class.
    /// Contains all methods for playing the High Card game.
    /// </summary>
    public class HighCardGame : CardSystem {
        /// <summary>
        /// Maximum number of menu options for user to select from.
        /// </summary>
        public const char MAX_CHOICES = '2';
        // Game currently supports 2 players.
        private int numOfPlayers = 2;
        // List of all players.
        private List<Player> players;

        /// <summary>
        /// Default constructor.
        /// Initializes all players in the game.
        /// </summary>
        public HighCardGame() {
            // Initialize players.
            this.players = new List<Player>(); 
            for (int i = 1; i <= this.numOfPlayers; i++) {
                Player newPlayer = new Player(i);
                this.players.Add(newPlayer);
            }
        }

        /// <summary>
        /// Gives a Card to each player.
        /// </summary>
        public void DealCards() {
            foreach (Player player in this.players) {
                DealCard(player);
            }
        }

        /// <summary>
        /// Prints each player's Card info
        /// </summary>
        public void ShowCards() {
            foreach (Player player in this.players) {
                ShowCard(player);
            }
        }

        /// <summary>
        /// Determines the player with the higher card and prints the winner
        /// </summary>
        public void ShowWinner() {
            // Initialize winner info.
            Card winningCard = null;
            Player winner = null;
            
            // Compare each player's card to the winner's.
            foreach (Player player in this.players) {
                // Get player's card.
                Card currCard = player.GetCard();
                // There is no current winner.
                if (winningCard == null) {
                    winningCard = currCard;
                    winner = player;
                }
                // This card's value is higher than winner's.
                else if (currCard.Value > winningCard.Value) {
                    winningCard = currCard;
                    winner = player;
                }
                // Both cards have the same value but this card's suit is higher than winner's.
                else if ((currCard.Value == winningCard.Value) && (currCard.Suit > winningCard.Suit)) {
                    winningCard = currCard;
                    winner = player;
                }
            }

            // Declare the winner.
            Console.WriteLine($"Player {winner.PlayerNum} Wins!");
        }

        /// <summary>
        /// Restarts the High Card game.
        /// </summary>
        public void RestartGame() {
            ResetDeck();
        }

        /// <summary>
        /// Display all menu options for High Card game.
        /// </summary>
        public static void DisplayGameMenu() {
            Console.WriteLine();
            Console.WriteLine("    MAIN MENU");
            Console.WriteLine("===================");
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Quit");
            Console.WriteLine();
        }
    }
}
