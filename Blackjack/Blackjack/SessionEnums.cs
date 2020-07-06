using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public enum GameMode
    {
        AILearn = 0,
        PlayerPractice = 1,
        PlayerCareer = 2
    }

    [Flags]
    public enum BoolRules
    {
        DoubleAfterSplit = 1,
        Soft17Hit = 2,
        SurrenderAllowed = 4,
        InsuranceAllowed = 8,
        FiveCardCharlie = 16
    }

    public enum BJPayout
    {
        TwoToOne,
        ThreeToTwo,
        SixToFive
    }
}
