namespace BullsAndCowsGame.Contracts
{
    public interface IMessageDispatcher
    {
        string GetScoreBoard(LeaderBoard<Player> leaderBoard);

        string GetCongatulationsMessage(Helper helper, int attempts);

        string GetWrongNumberMessage(int bullsCount, int cowsCount);

        string GetWelcomeMessage();

        string GetGoodbyeMessage();

        string GetInvalidCommandMessage();

        string GetNoCheatersMessage();

        string GetEnterNameMessage();

        string GetEnterCommandMessage();
    }
}
