namespace BullsAndCowsGame
{
    using System;

    public class BullsAndCows
    {
        public static void Main()
        {
            GameEngine game = GameEngine.Instance;
            game.Start();
        }
    }
}
