using System;
using HighCardGame.Cards;

namespace HighCardGame.Players {
    public class Player {
        // Current card that the player is holding
        private Card card;
        // Player's number identifier
        public int PlayerNum { get; }

        // Constructor
        public Player(int num) {
            this.PlayerNum = num;
        }

        // Show the player's current card
        public Card showCard() {
            return card;
        }
        // Deals the player a new card
        public void dealCard(Card newCard)  {
            this.card = newCard;
            Console.WriteLine("Card: " + this.card.Suit + " " + this.card.Value);
        }
    }
}