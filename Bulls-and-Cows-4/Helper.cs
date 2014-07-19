namespace BullsAndCowsGame
{
    using System;
    using System.Text;

    public class Helper
    {
        private int cheats;
        private readonly StringBuilder helpNumber;
        private readonly string helpPattern;

        public Helper()
        {
            this.Cheats = 0;
            this.helpNumber = new StringBuilder("XXXX");
            this.helpPattern = this.GenerateHelpPattern();
        }

        public int Cheats
        {
            get
            {
                return this.cheats;
            }

            set
            {
                this.cheats = value;
            }
        }

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

        private void RevealDigit(string generatedNumber)
        {
            if (this.helpPattern == null)
            {
                this.GenerateHelpPattern();
            }

            int digitToReveal = this.helpPattern[this.cheats] - '0';
            this.helpNumber[digitToReveal - 1] = generatedNumber[digitToReveal - 1];
        }

        private string GenerateHelpPattern()
        {
            string[] helpPaterns = 
            {
                "1234", "1243", "1324", "1342", "1432", "1423",
                "2134", "2143", "2314", "2341", "2431", "2413",
                "3214", "3241", "3124", "3142", "3412", "3421",
                "4231", "4213", "4321", "4312", "4132", "4123",
            };

            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);
            int randomPaternNumber = randomNumberGenerator.Next(helpPaterns.Length - 1);

            return helpPaterns[randomPaternNumber];
        }
    }
}
