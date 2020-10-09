using System;

namespace Monopoly_Simulation.Model
{
    public class Die
    {
        private int _eyes;
        
        private readonly Random _random = new Random();

        public Die(int eyes)
        {
            _eyes = eyes + 1;
        }

        public int Roll()
        {
            return _random.Next(1, _eyes);
        }

        public static Die CreateSixEyedDie()
        {
            return new Die(6);
        }
    }
}