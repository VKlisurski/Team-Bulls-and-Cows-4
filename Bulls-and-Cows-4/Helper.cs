namespace BullsAndCowsGame
{
    using System;
    using System.Text;

    internal class Helper
    {
        private static Helper instance;
        private int cheats;
        private StringBuilder helpNumber;
        string helpPattern = null;

        private Helper()
        {
            this.cheats = 0;
            this.helpNumber = new StringBuilder("XXXX");
            this.helpPattern = null;
        }

        public static Helper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Helper();
                }

                return instance;
            }
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



        public void DisplayHelp(string generatedNumber)
        {
            if (this.cheats < 4)
            {
                this.RevealDigit(generatedNumber);
                this.cheats++;
                Console.WriteLine("The number looks like {0}.", this.helpNumber);
            }
            else
            {
                Console.WriteLine("You are not allowed to ask for more help!");
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

        private void GenerateHelpPattern()
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
            this.helpPattern = helpPaterns[randomPaternNumber];
        }
    }
}
