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

        // Constructor
        public CardSystem() {
            // Create a standard playing card deck
            deck = new List<Card>();
            resetDeck();
            
            // Initialize players
            players = new List<Player>(); 
            for (int i = 1; i <= numOfPlayers; i++) {
                Player newPlayer = new Player(i);
                players.Add(newPlayer);
            }
        }

        private void resetDeck() {
            foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit))) {
                for (int i = 2; i <= Card.maxValue; i++) {
                    Card newCard = new Card(suit, i);
                    // Add card to the deck
                    deck.Add(newCard);
                }
            }
        }

        // Randomize the cards order in the deck
        public void shuffleDeck() {

        }

        // Deal a single card to each player
        public void dealCards() {
            foreach (Player player in players) {
                Card cardToDeal = deck[0];
                player.dealCard(cardToDeal);
                deck.Remove(cardToDeal);
            }
        }

        // Restart the game and reset deck
        public void restartGame() {
            Console.WriteLine("Restart game...");
            resetDeck();
        }

        // Display each player's card and declare the winner
        public void getWinner() {

        }
    }
}