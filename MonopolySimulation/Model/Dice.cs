using System.Collections.Generic;

namespace Monopoly_Simulation.Model
{
    public class Dice
    {
        private IEnumerable<Die> _dice;
        
        public Dice(params Die[] dice)
        {
            _dice = dice;
        }

        public int Roll()
        {
            int allEyes = 0;
            
            foreach (Die die in _dice)
            {
                allEyes += die.Roll();
            }
            
            return allEyes;
        }
    }
}