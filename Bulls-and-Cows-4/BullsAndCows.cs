namespace BullsAndCowsGame
{
    using System;
    using System.Text;

    public class BullsAndCows
    {
        public static void Main()
        {
            GameEngine game = GameEngine.Instance;
            game.Start();
        }
    }
}
