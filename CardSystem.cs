using System;
using System.Collections.Generic;
using System.Linq;
using HighCardGame.Cards;
using HighCardGame.Players;

namespace HighCardGame.CardSystems {
    public class CardSystem {
        private List<Card> deck;        // List of all the cards in a single game
        private int numOfPlayers = 2;   // Game currently supports 2 players
        private List<Player> players;   // List of all players
        private Random rand;            // Random object to generate indexes

        // Constructor
        public CardSystem() {
            // Create a standard playing card deck
            deck = new List<Card>();
            ResetDeck();
            
            // Initialize players
            players = new List<Player>(); 
            for (int i = 1; i <= numOfPlayers; i++) {
                Player newPlayer = new Player(i);
                players.Add(newPlayer);
            }

            // Instantiate Random object
            rand = new Random();
        }

        // Reset to a full standard playing deck
        private void ResetDeck() {
            foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit))) {
                for (int i = 2; i <= Card.maxValue; i++) {
                    Card newCard = new Card(suit, i);
                    // Add card to the deck
                    deck.Add(newCard);
                }
            }
        }

        // Generate a random index into the deck to imitate
        // shuffling the cards
        public int ShuffleDeck() {
            Console.WriteLine("Shuffling the deck...");
            return rand.Next(0, deck.Count);
        }

        // Deal a single card to each player
        public void DealCards() {
            foreach (Player player in players) {
                // Get a random card from the deck
                int index = ShuffleDeck();
                Card cardToDeal = deck[index];
                player.DealCard(cardToDeal);
                // Remove the dealt card from the deck to avoid duplicates
                deck.Remove(cardToDeal);
            }
        }

        // Restart the game and reset deck
        public void RestartGame() {
            Console.WriteLine("Restart game...");
            ResetDeck();
        }

        // Display each player's card and declare the winner
        public void GetWinner() {
            Card winningCard = null;
            Player winner = null;
            // Print each player's card
            foreach (Player player in players) {
                Card currCard = player.GetCard();
                Console.WriteLine("Player " + player.PlayerNum + ": " +
                    currCard.GetCardStr());
                // Determine whether this player's card is higher than the current winning card
                if (winningCard == null || (currCard.Value > winningCard.Value)) {
                    winningCard = currCard;
                    winner = player;
                }
                // Use suit if there is a tie in card value
                else if (winningCard != null && (currCard.Value == winningCard.Value)) {
                    if (currCard.Suit > winningCard.Suit) {
                        winningCard = currCard;
                        winner = player;
                    }
                }
            }
            // Declare the winner
            Console.WriteLine("Player " + winner.PlayerNum + " Wins!");
        }
    }
}