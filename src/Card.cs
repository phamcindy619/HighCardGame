using System;

namespace CardGame.Cards {
    /// <summary>
    /// The main Card class.
    /// Contains all Card types and methods for displaying Card info.
    /// </summary>
    public class Card {
        /// <summary>
        /// A card suit category enum.
        /// </summary>
        public enum CardSuit {
            /// <summary>
            /// The Spades suit type.    
            /// </summary>    
            Spades,
            /// <summary>
            /// The Clubs suit type.    
            /// </summary>  
            Clubs,
            /// <summary>
            /// The Diamonds suit type.    
            /// </summary>  
            Diamonds,
            /// <summary>
            /// The Hearts suit type.    
            /// </summary>  
            Hearts
        }
        /// <summary>
        /// The maximum face value a card can have.
        /// </summary>
        public const int MAX_VAL = 14;
        /// <value>Gets the suit type of this Card.</value>
        public CardSuit Suit { get; }
        /// <value>Gets the face value of this Card.</value>
        public int Value { get; }

        /// <summary>
        /// Overloaded constructor. 
        /// Initializes this Card to a suit type <paramref name="suit"/> and face value <paramref name="val"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="val"/> is less than or greater than the maximum value allowed.
        /// </exception>
        /// <param name="suit">A CardSuit type.</param>
        /// <param name="val">An integer value.</param>
        public Card(CardSuit suit, int val) {
            this.Suit = suit;
            // Validate the card value.
            if (val < 2 || val > MAX_VAL)
                throw new ArgumentOutOfRangeException("Card value must be between 2 and " + val);
            else
                this.Value = val;
        }

        /// <summary>
        /// Returns the String containing this Card's value and suit.
        /// </summary>
        /// <returns>
        /// String containing this Card's value and suit.
        /// </returns>
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
            return $"{valStr} of {this.Suit}";
        }
    }
}