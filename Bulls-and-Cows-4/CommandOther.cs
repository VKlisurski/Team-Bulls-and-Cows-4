using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    class CommandOther: Command
    {
        public CommandOther(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute()
        {
            //TODO
            engine.Action();
        }
    }
}
