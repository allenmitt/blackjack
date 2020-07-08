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
        // 0 = AI, 1 = New Player game, 2 = continue player game
        public byte mGameMode { get; private set; }

        // Number of decks per shoe
        private int mNumDecks { get; set; }

        // several boolean game variations stored in a single byte
        private byte mBoolRules { get; set; }

        // 0 = 2:1, 1 = 3:2, 2 = 6:5
        private byte mPayout { get; set; }

        // Shoe object. Only one created per session and reshuffled
        private Shoe mShoe { get; set; }            

        // Player object. Tracks AI and/or human players' decision history
        // and various other attributes
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

            CreatePlayer(this);
        }
        #endregion

        #region Public Methods
        public List<Card> PlayHand()
        {
            Hand hand = new Hand(mShoe, mPlayer);

        }
        #endregion

        #region Private Members
        /// <summary>
        /// Generates a new shoe to be used during the session
        /// </summary>
        /// <returns>Shoe object</returns>
        private Shoe CreateShoe()
        {
            this.mShoe = new Shoe(this.mNumDecks);
            return this.mShoe;
        }

        /// <summary>
        /// Instantiates player object. Can be an AI or human player
        /// </summary>
        /// <param name="session">The session creating the player. Always use 'this'</param>
        /// <returns>Instantiated Player object</returns>
        private Player CreatePlayer(Session session)
        {
            this.mPlayer = new Player(session);
            return this.mPlayer;
        }
        #endregion

    }
}
