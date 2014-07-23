namespace BullsAndCowsGame
{
    public abstract class FactoryMethod
    {
        public abstract Command Create(string commandName, GameEngine engine);
    }
}