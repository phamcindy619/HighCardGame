using System;
using System.Collections.Generic;
using HighCardGame.Cards;
using HighCardGame.Players;

namespace HighCardGame.CardSystems {
    /// <summary>
    /// The main CardSystem class.
    /// Contains all data and methods for performing High Card game functions.
    /// </summary>
    public class CardSystem {
        // List of all the cards in a single game.
        private List<Card> deck;
        // Game currently supports 2 players.
        private int numOfPlayers = 2;
        // List of all players.
        private List<Player> players;
        // Random object to generate indexes.
        private Random rand;

        /// <summary>
        /// Default constructor.
        /// Creates a new deck of cards and new list of players.
        /// </summary>
        public CardSystem() {
            deck = new List<Card>();
            // Create a standard playing card deck
            ResetDeck();
            
            // Initialize players
            players = new List<Player>(); 
            for (var i = 1; i <= numOfPlayers; i++) {
                Player newPlayer = new Player(i);
                players.Add(newPlayer);
            }

            // Instantiate Random object
            rand = new Random();
        }

        private void ResetDeck() {
            deck.Clear();
            foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit))) {
                for (var i = 2; i <= Card.MAX_VAL; i++) {
                    Card newCard = new Card(suit, i);
                    // Add card to the deck
                    deck.Add(newCard);
                }
            }
        }

        private Card GetRandomCard() {
            int index = rand.Next(0, deck.Count);
            return deck[index];
        }

        /// <summary>
        /// Deals a single random card from the deck to each player.
        /// </summary>
        public void DealCards() {
            foreach (Player player in players) {
                // Get a random card from the deck
                Card cardToDeal = GetRandomCard();
                player.DealCard(cardToDeal);
                // Remove the dealt card from the deck to avoid duplicates
                deck.Remove(cardToDeal);
            }
        }


        /// <summary>
        /// Restarts the High Card game and resets the deck to a full standard deck.
        /// </summary>
        public void RestartGame() {
            ResetDeck();
        }

        /// <summary>
        /// Prints each player's card info.
        /// </summary>
        public void ShowCards() {
            foreach (Player player in players) {
                Card currCard = player.GetCard();
                Console.WriteLine($"Player {player.PlayerNum}: " + currCard.GetCardStr());
            }

        }

        /// <summary>
        /// Determines the player with the higher card and prints the winner
        /// </summary>
        public void ShowWinner() {
            // Initialize winner info
            Card winningCard = null;
            Player winner = null;
            
            // Compare each player's card to the winner's
            foreach (Player player in players) {
                // Get player's card
                Card currCard = player.GetCard();
                // There is no current winner
                if (winningCard == null) {
                    winningCard = currCard;
                    winner = player;
                }
                // This card's value is higher than winner's 
                else if (currCard.Value > winningCard.Value) {
                    winningCard = currCard;
                    winner = player;
                }
                // Both cards have the same value but this card's suit is higher than winner's
                else if ((currCard.Value == winningCard.Value) && (currCard.Suit > winningCard.Suit)) {
                    winningCard = currCard;
                    winner = player;
                }
            }

            // Declare the winner
            Console.WriteLine($"Player {winner.PlayerNum} Wins!");
        }
    }
}