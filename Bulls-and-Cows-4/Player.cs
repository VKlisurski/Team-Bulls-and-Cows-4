namespace BullsAndCowsGame
{
    using System;

    /// <summary>
    /// Holds information about the player name and number of guess attempts made in a game.
    /// </summary>
    public class Player : IComparable<Player>
    {
        /// <summary>
        /// The player name.
        /// </summary>
        private string name;

        /// <summary>
        /// The amount of attempts the player made.
        /// </summary>
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
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
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

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">The object to compare with the current instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Less than zero if this instance precedes other in the sort order. Zero if this instance instance occurs in the same position in the sort order as other. Greater than zero if this instance follows other in the sort order.</returns>
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