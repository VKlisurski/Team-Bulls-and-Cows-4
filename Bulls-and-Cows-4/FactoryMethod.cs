namespace BullsAndCowsGame
{
    internal abstract class FactoryMethod
    {
        public abstract Command Create(string commandName, GameEngine engine);
    }
}
