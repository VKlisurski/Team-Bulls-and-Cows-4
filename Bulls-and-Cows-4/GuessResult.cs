using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    /// <summary>
    /// Contains information about how many bulls and how many cows are in a given guess.
    /// </summary>
    public class GuessResult
    {
        public GuessResult(int bulls, int cows)
        {
            this.Bulls = bulls;
            this.Cows = cows;
        }

        /// <summary>
        /// Gets or sets the amount of bulls for the current guess.
        /// </summary>
        public int Bulls { get; set; }

        /// <summary>
        /// Gets or sets the amount of cows for the current guess.
        /// </summary>
        public int Cows { get; set; }
    }
}