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
        //Stores a signed integer indicated money won/lost
        public int Money { get; set; }

        //Integer indicating amount of bet placed each hand
        public int BetAmount { get; set; }
        #endregion

        #region Private Properties
        //Dictionary logging past decisions
        private Dictionary<string, DecisionHistory> mDecisions { get; set; }
        #endregion

        #region .ctor
        public Player(Session session)
        {
            switch (session.mGameMode)
            {
                case 0:     // Player is AI
                    break;  
                case 1:     // Player is human and starting a new session
                    break;  // Not implemented yet
                case 2:     // Player is human and resuming a saved session
                    break;  // Not implemented yet
                default:
                    throw new NotImplementedException();                    
            }
        }
        #endregion

        #region Public Methods
        public void AIMakeDecision()
        {

        }

        public void HumanMakeDecision()
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
