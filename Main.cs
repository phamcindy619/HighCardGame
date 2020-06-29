using System;
using HighCardGame.CardSystems;

namespace HighCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            CardSystem game = new CardSystem();
            game.dealCards();
        }
    }
}
