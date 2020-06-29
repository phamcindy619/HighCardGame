using System;
namespace HighCardGame.Cards {
    // Defines the Card type
    public class Card {
        public const int maxValue = 14;

        public enum CardSuit {
            Spades,
            Clubs,
            Diamonds,
            Hearts
        }

        public enum CardValue {
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = maxValue
        }

        public CardSuit Suit { get; }
        public int Value { get; }

        // Constructor
        public Card(CardSuit suit, int val) {
            this.Suit = suit;
            // Validate card value
            if (val < 2 || val > maxValue)
                Console.WriteLine("Card value must be between 2 and " + val);
            else
                this.Value = val;
        }
    }
}