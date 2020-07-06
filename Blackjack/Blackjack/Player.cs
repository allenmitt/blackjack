using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        #region Public Properties
        public int Money { get; set; } //Stores a signed integer indicated money won/lost

        public int BetAmount { get; set; } //Integer indicating amount of bet placed each hand

        private DecisionHistory mDecisions { get; set; } //Complex dictionary logging past decisions
        #endregion

        #region .ctor
        public Player(Session session)
        {
            switch (session.mGameMode)
            {
                case 0:     // Player is AI

                    break;
                case 1:
                    break; //Not implemented yet
                case 2:
                    break; //Not implemented yet
                default:
                    throw new NotImplementedException();                    
            }
        }
        #endregion

        #region Public Methods
        public void MakeDecision()
        {

        }

        public void LogDecision()
        {

        }
        #endregion
    }

    /// <summary>
    /// Choices a player can make at any time. Bitwise calculations used to
    /// determine available options in each case.
    /// </summary>
    public enum PlayerChoice
    {
        Hit = 1,
        Stand = 2,
        DoubleDown = 4,
        Split = 8,
        Surrender = 16,
        TakeInsurance = 32,
        TakeEvenMoney = 64
    }
}
