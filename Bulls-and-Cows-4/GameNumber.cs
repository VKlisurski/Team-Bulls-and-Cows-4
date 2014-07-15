using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    internal static class GameNumber
    {
        internal static string Generate(int defaultNumberLength)
        {
            StringBuilder num = new StringBuilder(4);
            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < defaultNumberLength; i++)
            {
                int randomDigit = randomNumberGenerator.Next(9);

                num.Append(randomDigit);
            }

            return num.ToString();
        }

        internal static bool IsItValid(string playerInput, int defaultNumberLength)
        {
            // Useless validation?
            if (playerInput == string.Empty || playerInput.Length != defaultNumberLength)
            {
                return false;
            }

            // May be try parse the input and return false on error?
            for (int i = 0; i < playerInput.Length; i++)
            {
                char currentChar = playerInput[i];

                if (!char.IsDigit(currentChar))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
