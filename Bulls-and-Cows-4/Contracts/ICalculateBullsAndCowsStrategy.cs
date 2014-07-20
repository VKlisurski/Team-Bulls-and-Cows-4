namespace BullsAndCowsGame.Contracts
{
    public interface ICalculateBullsAndCowsStrategy
    {
        void ExecuteStrategy(string playerInput, string generatedNumber, out int bullsCount, out int cowsCount);
    }
}
