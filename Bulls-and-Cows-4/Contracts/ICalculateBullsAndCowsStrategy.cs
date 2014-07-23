namespace BullsAndCowsGame.Contracts
{
    public interface ICalculateBullsAndCowsStrategy
    {
        GuessResult ExecuteStrategy(string playerInput, string generatedNumber);
    }
}