using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Hand
    {
        List<Card> mCardsInHand = new List<Card>();

        Card mUpCard;

        public Hand(List<Card> cards, Card upCard)
        {
            mCardsInHand = cards;
            mUpCard = upCard;

            EvaluateHand(cards, upCard);
        }

        private int EvaluateHand(List<Card> playerHand, Card dealerUpCard)
        {
            int value = 0;

            while (value <= 21)
            {
                foreach (Card card in playerHand)
                {
                    // Check if face card and evaluate as 10, else add face value
                    if (Enum.IsDefined(typeof(FaceCards), card))
                    {
                        value += 10;            // If it's a face card add 10
                    }                    
                    else if ((int)card.mCardNumber != 1)
                    {
                        value += (int)card.mCardNumber; // else add value of card
                    }

                }
            }
            
        }
    }

    public enum HardSoft
    {
        Hard,
        Soft
    }
}
