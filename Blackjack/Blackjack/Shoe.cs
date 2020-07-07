using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    /// <summary>
    /// Shuffles and builds a shoe based on the player's chosen rules and game 
    /// mode. Only one shoe should be created per session. Shoe object retains
    /// current information throughout the session.
    /// </summary>
    public class Shoe
    {
        #region Properties
        public bool IsDepleted { get; private set; } = false;

        public List<Card> Cards { get; private set; } = new List<Card>();

        public int RunningCount { get; private set; } = 0;

        public int TrueCount { get; private set; } = 0;
        #endregion

        #region .ctor
        /// <summary>
        /// Creates a shoe of multiple decks of cards
        /// </summary>
        /// <param name="numDecks">Number of decks to to be added to the shoe</param>
        public Shoe(int numDecks)
        {
            // Creates a new deck numDecks amount of times and combines resulting
            // cards into a single shoe
            for (int i = 0; i < numDecks; i++)
            {
                Deck deck = new Deck();
                foreach (Card card in deck.Cards)
                {
                    this.Cards.Add(card);
                }
            }

            // Shuffles all cards in the shoe (multiple decks)
            this.Cards = Shuffle(this.Cards);
        }
        #endregion

        #region Public Methods
        public int CalculateCounts()
        {
            return 0; //TODO: IMPLEMENT LATER*************************************************************
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Shuffles the shoe using RND
        /// </summary>
        /// <param name="list">Shoe of cards to be shuffled</param>
        /// <returns>List item containing a shuffled card shoe</returns>
        private static List<Card> Shuffle(List<Card> list)
        {
            List<Card> temp = new List<Card>(); // Create a placeholder list
            Random r = new Random(); // Create an instance of randome number generator

            // Iterate through shoe and randomly move cards to new temp list
            while (list.Count > 0)
            {
                int i = r.Next(0, list.Count); // pick a random card from shoe
                temp.Add(list[i]); // add randomly selected card to temp list
                list.RemoveAt(i); // removes chosen card from original list
            }

            return temp; // return temp list for assignment
        }
        #endregion
    }
}
