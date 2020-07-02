using System;
using System.Collections.Generic;
using CardGames.Cards;
using CardGames.Players;

namespace CardGames.CardSystems {
    /// <summary>
    /// The main CardSystem class.
    /// Contains all methods for performing Standard Playing Card game functionalities.
    /// </summary>
    public class CardSystem {
        // List of all the cards in a single game.
        private List<Card> deck;
        // Random object to generate indexes.
        private Random rand;

        /// <summary>
        /// Default constructor.
        /// Creates a new deck of cards and new list of players.
        /// </summary>
        public CardSystem() {
            // Create a standard playing card deck.
            this.deck = new List<Card>();
            ResetDeck();

            // Instantiate Random object.
            this.rand = new Random();
        }

        /// <summary>
        /// Resets the deck to a full standard deck.
        /// </summary>
        public void ResetDeck() {
            // Clear the current deck.
            this.deck.Clear();
            // Create Cards for each suit and value for the standard deck.
            foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit))) {
                // Card values begins at 2.
                for (int i = 2; i <= Card.MAX_VAL; i++) {
                    Card newCard = new Card(suit, i);
                    // Add card to the deck.
                    this.deck.Add(newCard);
                }
            }
        }

        // Returns a random card from the deck
        private Card GetRandomCard() {
            int index = rand.Next(0, this.deck.Count);
            return this.deck[index];
        }

        /// <summary>
        /// Deals a single random card from the deck to the player.
        /// </summary>
        public void DealCard(Player player) {
            // Get a random card from the deck.
            Card cardToDeal = GetRandomCard();
            player.DealCard(cardToDeal);
            // Remove the dealt card from the deck to avoid duplicates.
            this.deck.Remove(cardToDeal);
        }

        /// <summary>
        /// Prints the player's card info.
        /// </summary>
        public void ShowCard(Player player) {
            Card currCard = player.GetCard();
            Console.WriteLine($"Player {player.PlayerNum}: " + currCard.GetCardStr());
        }
    }
}

