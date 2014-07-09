using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    internal abstract class Command
    {
        protected GameEngine engine;

        public Command(GameEngine engine)
        {
            this.engine = engine;
        }

        public abstract void Execute();
    }
}
