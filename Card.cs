namespace CardNS {
    // Defines the Card type
    public class Card {

        enum CardSuit {
            Spades,
            Clubs,
            Diamonds,
            Hearts
        }

        enum CardValue {
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14
        }

        public CardSuit Suit 
        { get; }

        public CardValue Value
        { get; }

        // Constructor
        public Card(CardSuit suit, CardValue val) {
            this.Suit = suit;
            this.Value = val;
        }
    }
}