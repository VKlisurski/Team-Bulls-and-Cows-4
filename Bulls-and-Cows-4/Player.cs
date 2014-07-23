namespace BullsAndCowsGame
{
    using System;

    /// <summary>
    /// Holds information about the player name and number of guess attempts made in a game.
    /// </summary>
    public class Player : IComparable<Player>
    {
        private string name;
        private int attempts;

        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.Player class.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="attempts">The number of guess attempts, the player made.</param>
        public Player(string name, int attempts)
        {
            this.Name = name;
            this.Attempts = attempts;
        }

        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the number of guess attempts, the player made.
        /// </summary>
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
                throw new ArgumentNullException("Cannot compare player to null");
            }

            return other.Attempts - this.Attempts;
        }
    }
}