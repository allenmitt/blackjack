using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    /// <summary>
    /// Defines the current session and its associated rules and modes
    /// </summary>
    public class Session
    {
        #region Private Properties
        public byte mGameMode { get; private set; }

        private int mNumDecks { get; set; }

        private byte mBoolRules { get; set; }

        private byte mPayout { get; set; }

        private Shoe mShoe { get; set; }

        private Player mPlayer { get; set; }
        #endregion

        #region .ctor
        /// <summary>
        /// Instantiates a new session based on rules and modes chosen by the user on the opening menu
        /// </summary>
        /// <param name="gameMode"></param>
        /// <param name="numDecks"></param>
        /// <param name="boolRules"></param>
        /// <param name="payout"></param>
        public Session(byte gameMode, int numDecks, byte boolRules, byte payout)
        {
            // Set all private properties with constructor parameters
            this.mGameMode = gameMode;
            this.mNumDecks = numDecks;
            this.mBoolRules = (byte)(BoolRules)boolRules;
            this.mPayout = payout;

            CreateShoe();

            //foreach (Card card in mShoe.Cards)
            //{
            //    Console.WriteLine($"{card.mCardNumber.ToString()} of {card.mSuit.ToString()}s");
            //}

            //Console.ReadLine();

            CreatePlayer(this);
        }
        #endregion

        #region Public Methods
        public List<Card> PlayHand()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private members

        /// <summary>
        /// Generates a new shoe to be used during the session
        /// </summary>
        /// <returns>Shoe object</returns>
        private Shoe CreateShoe()
        {
            this.mShoe = new Shoe(this.mNumDecks);
            return this.mShoe;
        }

        private Player CreatePlayer(Session session)
        {
            this.mPlayer = new Player(session);
            return this.mPlayer;
        }
        #endregion

    }
}
