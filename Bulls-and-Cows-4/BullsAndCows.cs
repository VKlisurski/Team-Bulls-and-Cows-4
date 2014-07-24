namespace BullsAndCowsGame
{
    /// <summary>
    /// An implementation of the popular Bulls and Cows game.
    /// </summary>
    public class BullsAndCows
    {
        /// <summary>
        /// The entry point of our Bulls and Cows game.
        /// </summary>
        public static void Main()
        {
            GameEngine game = GameEngine.Instance;
            game.Start();
        }
    }
}