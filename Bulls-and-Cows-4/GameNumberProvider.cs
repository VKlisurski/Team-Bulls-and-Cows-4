namespace BullsAndCowsGame
{
    using System;
    using System.Text;

    public class GameNumberProvider
    {
        public string Generate(int defaultNumberLength)
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

        public bool IsItValid(string playerInput, int defaultNumberLength)
        {
            if (playerInput == string.Empty || playerInput.Length != defaultNumberLength)
            {
                return false;
            }

            int expected;
            return Int32.TryParse(playerInput, out expected);
        }
    }
}
