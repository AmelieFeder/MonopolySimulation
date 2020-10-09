using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly_Simulation;
using Monopoly_Simulation.Model;

namespace MonopolyTests
{
    [TestClass]
    public class GameboardTests
    {
        [TestMethod]
        public void Gameboard_Postitive_Overflow_Test()
        {
            List<Space> spaces = DataLoader.LoadSpaces().ToList();
            
            Gameboard gameboard = new Gameboard(spaces);
            gameboard.PositionOfPlayer = 38;
            gameboard.MoveByDiceResult(5);

            var actual = gameboard.PositionOfPlayer;
            var expected = 3;
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Gameboard_Negative_Overflow_Test()
        {
            List<Space> spaces = DataLoader.LoadSpaces().ToList();
            
            Gameboard gameboard = new Gameboard(spaces);
            gameboard.PositionOfPlayer = 0;
            gameboard.MoveByDiceResult(-1);

            var actual = gameboard.PositionOfPlayer;
            var expected = 39;
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Move_To_Next_Vehicle_When_Behind_All_Vehicles()
        {
            List<Space> spaces = DataLoader.LoadSpaces().ToList();
            
            Gameboard gameboard = new Gameboard(spaces);
            gameboard.PositionOfPlayer = 36;
            
            gameboard.MoveToNextVehicle();
            
            Assert.AreEqual(5, gameboard.PositionOfPlayer);
        }
        
        [TestMethod]
        public void Can_Move_To_Next_Vehicle_When_In_Front_Of_All_Vehicles()
        {
            List<Space> spaces = DataLoader.LoadSpaces().ToList();
            
            Gameboard gameboard = new Gameboard(spaces);
            gameboard.PositionOfPlayer = 0;
            
            gameboard.MoveToNextVehicle();
            
            Assert.AreEqual(5, gameboard.PositionOfPlayer);
        }
        
        [TestMethod]
        public void Can_Move_To_Next_Vehicle_When_In_Between_Of_Vehicles()
        {
            List<Space> spaces = DataLoader.LoadSpaces().ToList();
            
            Gameboard gameboard = new Gameboard(spaces);
            gameboard.PositionOfPlayer = 16;
            
            gameboard.MoveToNextVehicle();
            
            Assert.AreEqual(25, gameboard.PositionOfPlayer);
        }
    }
}