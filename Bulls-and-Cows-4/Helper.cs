namespace BullsAndCowsGame
{
    using System;
    using System.Text;

    /// <summary>
    /// A class providing functionality for the usage of cheats in the game.
    /// </summary>
    public class Helper
    {        
        private readonly StringBuilder helpNumber;
        private readonly string helpPattern;
        private readonly string[] helpPatterns = 
        {
            "1234", "1243", "1324", "1342", "1432", "1423",
            "2134", "2143", "2314", "2341", "2431", "2413",
            "3214", "3241", "3124", "3142", "3412", "3421",
            "4231", "4213", "4321", "4312", "4132", "4123",
        };

        private int cheats;

        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.Helper class.
        /// </summary>
        public Helper()
        {
            this.Cheats = 0;
            this.helpNumber = new StringBuilder("XXXX");
            this.helpPattern = this.GenerateHelpPattern();
        }

        /// <summary>
        /// Gets or sets the number of cheats used by the player.
        /// </summary>
        public int Cheats
        {
            get
            {
                return this.cheats;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("A player cannot have a negative amount of cheats in a game.");
                }

                if (value > 3)
                {
                    throw new ArgumentException("A player is not allowed to have more than 3 cheats in a game.");
                }

                this.cheats = value;
            }
        }

        /// <summary>
        /// Gets a string representing the original number with some of it's digits revealed.
        /// </summary>
        /// <param name="generatedNumber">The original generated number.</param>
        /// <returns>A string representing the original number with some of it's digits revealed.</returns>
        public string GetHelp(string generatedNumber)
        {
            if (this.cheats < 4)
            {
                this.RevealDigit(generatedNumber);
                this.cheats++;

                return string.Format("The number looks like {0}.", this.helpNumber);
            }
            else
            {
                return string.Format("You are not allowed to cheat anymore!");
            }
        }

        /// <summary>
        /// Reveals a digit of the original generated number.
        /// </summary>
        /// <param name="generatedNumber">The original generated number.</param>
        private void RevealDigit(string generatedNumber)
        {
            if (this.helpPattern == null)
            {
                this.GenerateHelpPattern();
            }

            int digitToReveal = this.helpPattern[this.cheats] - '0';
            this.helpNumber[digitToReveal - 1] = generatedNumber[digitToReveal - 1];
        }

        /// <summary>
        /// Generates a help pattern.
        /// </summary>
        /// <returns>A help pattern.</returns>
        private string GenerateHelpPattern()
        {
            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);
            int randomPaternNumber = randomNumberGenerator.Next(this.helpPatterns.Length - 1);

            return this.helpPatterns[randomPaternNumber];
        }
    }
}