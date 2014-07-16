﻿using System;
namespace BullsAndCowsGame
{
    internal class CommandHelp : Command
    {
        public CommandHelp(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute(InputOutput inputOutput)
        {
            inputOutput.WriteLine(Engine.GetHelp());
        }
    }
}
