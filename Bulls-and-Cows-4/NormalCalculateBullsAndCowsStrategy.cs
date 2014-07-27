namespace BullsAndCowsGame
{
    using System;
    using System.Text;
    using Contracts;

    /// <summary>
    /// A strategy class, providing method for calculating the number of bulls and cows for normal difficulty.
    /// </summary>
    public class NormalCalculateBullsAndCowsStrategy : ICalculateBullsAndCowsStrategy
    {
        /// <summary>
        /// Executes the current strategy.
        /// </summary>
        /// <param name="playerInput">The guess number entered by the player.</param>
        /// <param name="generatedNumber">The original number that needs to be found out.</param>
        /// <returns>An object containing information about how many bulls and how many cows did the current guess number have.</returns>
        public GuessResult ExecuteStrategy(string playerInput, string generatedNumber)
        {
            int bullsCount = 0;
            int cowsCount = 0;
            StringBuilder playerNumber = new StringBuilder(playerInput);
            StringBuilder number = new StringBuilder(generatedNumber);
            for (int i = 0; i < playerNumber.Length; i++)
            {
                if (playerNumber[i] == number[i])
                {
                    bullsCount++;
                    playerNumber.Remove(i, 1);
                    number.Remove(i, 1);
                    i--;
                }
            }

            for (int i = 0; i < playerNumber.Length; i++)
            {
                for (int j = 0; j < number.Length; j++)
                {
                    if (playerNumber[i] == number[j])
                    {
                        cowsCount++;
                        playerNumber.Remove(i, 1);
                        number.Remove(j, 1);
                        j--;
                        i--;
                        break;
                    }
                }
            }

            return new GuessResult(bullsCount, cowsCount);
        }
    }
}