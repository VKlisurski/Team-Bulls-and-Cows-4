using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public interface ICalculateBullsAndCowsStrategy
    {
        void ExecuteStrategy(string playerInput, string generatedNumber, out int bullsCount, out int cowsCount);
    }
}
