using System;
using HighCardGame.Cards;

namespace HighCardGame.Players {
    /// <summary>
    /// The main Player class.
    /// Contains all data and methods for player interaction with the Card System.
    /// </summary>
    public class Player {
        private Card card;
        /// <value>Gets the player's identifier number.</value>
        public int PlayerNum { get; }

        /// <summary>
        /// Overloaded constructor.
        /// Initializes the player with an identifier number <paramref name="num"/>.
        /// </summary>
        /// <param name="num">An integer number.</param>
        public Player(int num) {
            this.PlayerNum = num;
        }

        /// <summary>
        /// Returns the current Card that this player is holding.
        /// </summary>
        /// <returns>
        /// The current Card.
        /// </returns>
        public Card GetCard() {
            return card;
        }

        /// <summary>
        /// Replaces the current Card that this player is holding with a new Card <paramref name="newCard"/>.
        /// </summary>
        /// <param name="newCard">A Card object.</param>
        public void DealCard(Card newCard)  {
            this.card = newCard;
        }
    }
}