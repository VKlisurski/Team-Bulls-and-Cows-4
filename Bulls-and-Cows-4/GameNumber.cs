namespace BullsAndCowsGame
{
    using System;
    using System.Text;

    /// <summary>
    /// A class used to provide a new number to be guessed by the player and validate a guess number entered by the player.
    /// </summary>
    public class GameNumber
    {
        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.GameNumberProvider class.
        /// </summary>
        public GameNumber()
        {
        }

        /// <summary>
        /// Generates a number with length specified by the defaultNumberLength parameter.
        /// </summary>
        /// <param name="defaultNumberLength">Specifies how many digits the number should have.</param>
        /// <returns>Generated number.</returns>
        public string Generate(int defaultNumberLength)
        {
            StringBuilder num = new StringBuilder(defaultNumberLength);
            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < defaultNumberLength; i++)
            {
                int randomDigit = randomNumberGenerator.Next(9);

                num.Append(randomDigit);
            }

            return num.ToString();
        }

        /// <summary>
        /// Checks if the number entered by the player is a valid "Bulls and Cows" number.
        /// </summary>
        /// <param name="playerInput">The number entered by the player.</param>
        /// <param name="defaultNumberLength">The default length a valid number should have.</param>
        /// <returns>true if the number is valid and false if it isn't.</returns>
        public bool IsValidNumber(string playerInput, int defaultNumberLength)
        {
            if (playerInput == string.Empty || playerInput.Length != defaultNumberLength)
            {
                return false;
            }

            int expected;
            return int.TryParse(playerInput, out expected);
        }
    }
}