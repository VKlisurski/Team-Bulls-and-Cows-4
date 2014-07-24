namespace BullsAndCowsGame
{
    using Contracts;

    /// <summary>
    /// 
    /// </summary>
    public class CommandTop : Command
    {
        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.CommandTop class.
        /// </summary>
        /// <param name="engine">The engine on which the current command would be executed on.</param>
        public CommandTop(IGameEngine engine) :
            base(engine)
        {
        }

        /// <summary>
        /// Executes the current command.
        /// </summary>
        /// <param name="inputOutput">The input and output to be used by the current command.</param>
        public override void Execute(InputOutput inputOutput)
        {
            LeaderBoard<Player> leaderboard = Engine.LeaderBoard;

            inputOutput.WriteLine(this.Engine.MessageDispatcher.GetScoreBoard(leaderboard));
        }
    }
}