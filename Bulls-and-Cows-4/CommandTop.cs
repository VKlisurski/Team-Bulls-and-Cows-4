namespace BullsAndCowsGame
{
    using Contracts;

    public class CommandTop : Command
    {
        public CommandTop(IGameEngine engine) :
            base(engine)
        {
        }

        public override void Execute(InputOutput inputOutput)
        {
            LeaderBoard<Player> leaderboard = Engine.GetScoreBoard();

            inputOutput.WriteLine(Message.GetScoreBoard(leaderboard));
        }
    }
}
