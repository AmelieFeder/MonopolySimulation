using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Monopoly_Simulation.Model;

namespace MonopolyTests
{
    [TestClass]
    public class DiceTests
    {
        [TestMethod]
        public void Test_If_Dice_Work()
        {
            Dice dice = new Dice();
            List<int> DiceResults = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                int eyes = dice.Roll();
                DiceResults.Add(eyes);
            }
            
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Test_If_Die_Works()
        {
            Die die = new Die(8);
            
            SortedDictionary<int, int> results = new SortedDictionary<int, int>();

            int rolls = 1_000_000;
            
            for (int i = 0; i < rolls; i++)
            {
                int rollResult = die.Roll();

                if (!results.ContainsKey(rollResult))
                {
                    results[rollResult] = 1;
                }
                else
                {
                    results[rollResult]++;
                }
            }

            foreach (int rollResultKey in results.Keys)
            {
                Console.WriteLine($"{rollResultKey}: {results[rollResultKey] / (decimal)rolls}");
            }
        }

        [TestMethod]
        public void Test_Dice_Configuration()
        {
            Dice dice = new Dice(Die.CreateSixEyedDie(), Die.CreateSixEyedDie(), new Die(20));

            SortedDictionary<int, int> results = new SortedDictionary<int, int>();

            int rolls = 1_000_000;
            
            for (int i = 0; i < rolls; i++)
            {
                int rollResult = dice.Roll();

                if (!results.ContainsKey(rollResult))
                {
                    results[rollResult] = 1;
                }
                else
                {
                    results[rollResult]++;
                }
            }

            foreach (int rollResultKey in results.Keys)
            {
                Console.WriteLine($"{rollResultKey}: {results[rollResultKey] / (decimal)rolls}");
            }
        }
        
    }
}