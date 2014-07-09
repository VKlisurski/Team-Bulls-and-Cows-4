using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    internal abstract class FactoryMethod
    {
        public abstract Command Create(string commandName, GameEngine engine);
    }
}
