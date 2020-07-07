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
            bool soft = false;

            while (value <= 21)
            {
                foreach (Card card in playerHand)
                {
                    // Check if face card and evaluate as 10, else add face value
                    // ignore if Ace
                    if (Enum.IsDefined(typeof(FaceCards), card))
                    {
                        value += 10;            // If it's a face card add 10
                    }                        
                    else if ((int)card.mCardNumber != 1)
                    {
                        value += (int)card.mCardNumber; // else add value of
                                                        // card if not ace
                    }
                    else
                    {
                        value += AceCard(playerHand, value, soft);  
                    }

                }
            }
            
        }

        private int AceCard(List<Card> playerHand, int value, bool soft)
        { 
            foreach (Card card in playerHand)
            {
                if ((int)card.mCardNumber == 1)     // If it's an Ace...
                {
                    if ((value + 11) > 21)          // Add 1 if 11 busts
                    {
                        value++;
                        soft = false; 
                    }
                    else
                    {
                        value += 11;                // Add 11 if not
                        soft = true;
                    }
                }
            }
            return value;
        }
    }

    public enum HardSoft
    {
        Hard,
        Soft
    }
}
