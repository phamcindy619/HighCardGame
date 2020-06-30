using System;

namespace HighCardGame.Cards {
    // Defines the Card type
    public class Card {
        public enum CardSuit {
            Spades,
            Clubs,
            Diamonds,
            Hearts
        }
        // The max face value a card can have
        public const int maxValue = 14;
        // The suit type of the card
        public CardSuit Suit { get; }
        // The face value of the card
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

        // Get String of the card's info 
        public String GetCardStr() {
            String valStr;
            switch (this.Value) {
                case 11:
                    valStr = "Jack";
                    break;
                case 12:
                    valStr = "Queen";
                    break;
                case 13:
                    valStr = "King";
                    break;
                case 14:
                    valStr = "Ace";
                    break;
                default:
                    valStr = this.Value.ToString();
                    break;
            }
            return valStr + " of " + this.Suit;
        }
    }
}