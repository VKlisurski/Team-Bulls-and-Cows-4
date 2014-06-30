namespace BullsAndCowsGame
{
    using System;
    using System.Linq;

    public class Player : IComparable<Player>
    {
        private string name;
        private int attempts;

        public Player(string name, int attempts)
        {
            this.Name = name;
            this.Attempts = attempts;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be null, empty or whitespaces only.");
                }

                this.name = value;
            }
        }

        public int Attempts
        {
            get
            {
                return this.attempts;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Attempts should be a positive number.");
                }

                this.attempts = value;
            }
        }

        public int CompareTo(Player other)
        {
            if (other == null)
            {
                return 1;
            }

            return other.Attempts - this.Attempts;
        }
    }
}
