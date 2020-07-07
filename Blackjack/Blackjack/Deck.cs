using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        // Create a list object to hold the cards
        public List<Card> Cards { get; private set; } = new List<Card>();

        /// <summary>
        /// Enumerate through Suit and CardNumber enums to create a full 52 card deck
        /// </summary>
        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardNumber number in Enum.GetValues(typeof(CardNumber)))
                {
                    Cards.Add(new Card(number, suit));                    
                }
            }
        }
    }

    /// <summary>
    /// Defines each card in the deck by it's suit and value
    /// </summary>
    public class Card
    {
        public Suit mSuit { get; private set; }

        public CardNumber mCardNumber { get; private set; }

        /// <summary>
        /// Sets the value and suit of each card as it is created
        /// </summary>
        /// <param name="number">Value of card</param>
        /// <param name="suit">Suit of card</param>
        public Card(CardNumber number, Suit suit)
        {
            this.mCardNumber = number;
            this.mSuit = suit;
        }
    }

    /// <summary>
    /// enum defining each suit of card by name
    /// </summary>
    public enum Suit
    {
        Club = 1,
        Diamond = 2,
        Heart = 3,
        Spade = 4
    }

    /// <summary>
    /// enum defining each value of card by name
    /// </summary>
    public enum CardNumber
    {
        Ace = 1,
        Two = 2,
        Three = 3, 
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    /// <summary>
    /// Defines face cards so they can all be easily assigned the same value during evaluations
    /// </summary>
    public enum FaceCards
    {        
        Jack,
        Queen,
        King
    }
}
