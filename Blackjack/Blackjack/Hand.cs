using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Hand
    {
        #region Public Properties
        public List<Card> mCardsInHand = new List<Card>();

        public string playerCardValue;

        public Card mUpCard;

        public string dealerCardValue;

        public bool ActiveHand = true;
        #endregion

        #region Private Properties
        private List<Card> mDealerHand = new List<Card>();

        private Shoe mShoe;

        private Player mPlayer;

        private bool mDealerBlackjack = false;

        private bool mPlayerBlackjack = false;
        #endregion

        #region .ctor
        public Hand(Shoe shoe, Player player)
        {
            this.mShoe = shoe;
            this.mPlayer = player;
        }
        #endregion

        private string InitialDeal()
        {
            // Deal card to player
            mCardsInHand.Add(mShoe.Cards[0]);
            mShoe.Cards.RemoveAt(0);

            // Deal up-card to dealer
            mUpCard = mShoe.Cards[0];
            mDealerHand.Add(mUpCard);
            mShoe.Cards.RemoveAt(0);

            // Deal 2nd card to player
            mCardsInHand.Add(mShoe.Cards[0]);
            mShoe.Cards.RemoveAt(0);

            // Add the value of the players cards
            playerCardValue = EvaluateHand(mCardsInHand);

            // Check if player has blackjack
            if (playerCardValue == "S21")
            {
                mPlayerBlackjack = true;
            }                

            // If dealer upcard is a 10 or face card, check for blackjack
            if (Enum.IsDefined(typeof(FaceCards), mUpCard) ||
                (int)mUpCard.mCardNumber == 10)
            {
                if ((int)mShoe.Cards[0].mCardNumber == 1)
                {
                    mDealerBlackjack = true;
                    mShoe.Cards.RemoveAt(0);
                    return null;
                }
            }
            // If dealer upcard is Ace, offer even money to player if they have
            // a blackjack, otherwise offer insurance. Then check for dealer 
            // blackjack
            else if ((int)mUpCard.mCardNumber == 1)
            {
                // TODO: Add code to offer player even money if they have black
                // jack or insurance if not

                if (Enum.IsDefined(typeof(FaceCards), mShoe.Cards[0]) ||
                    (int)mShoe.Cards[0].mCardNumber == 10)
                {
                    mDealerBlackjack = true;
                    mShoe.Cards.RemoveAt(0);
                    return null;
                }
            }
            else
            {

                dealerCardValue = EvaluateHand(mDealerHand);
            }

            return $"{playerCardValue}vs{dealerCardValue}";
        }

        private string EvaluateHand(List<Card> playerHand)
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
                        value += AceCard(playerHand, value, ref soft);  
                    }
                }
                break;
            }

            if (soft)
                return $"S{value}";
            else
                return $"H{value}";            
        }

        private int AceCard(List<Card> playerHand, int value, ref bool soft)
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
