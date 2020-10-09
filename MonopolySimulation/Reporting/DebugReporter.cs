using System.Collections.Generic;
using ConsoleTables;
using Monopoly_Simulation.Model;

namespace Monopoly_Simulation.Reporting
{
    public class DebugReporter : IReporter
    {
        private List<Space> _spaces;
        List<DebugReportData> _debugList = new List<DebugReportData>();
        private DebugReportData _data;

        public DebugReporter(List<Space> spaces)
        {
            _spaces = spaces;
        }

        public void StartRound()
        {
            _data = new DebugReportData();
        }

        public void AddInitialSpace(int spaceNumber)
        {
            _data.InitialSpace = _spaces[spaceNumber];
        }

        public void AddRollResult(int eyes)
        {
            _data.RollResult = eyes;
        }
        public void AddRollDestinationSpace(int spaceNumber)
        {
            _data.RollDestinationSpace = _spaces[spaceNumber];
        }

        public void AddSpaceAction(string action)
        {
            _data.SpaceAction = action;
        }

        public void AddSpaceActionDestinationSpace(int spaceNumber)
        {
            _data.SpaceActionDestinationSpace = _spaces[spaceNumber];
        }

        public void AddCardAction(string action)
        {
            _data.CardAction = action;
        }

        public void AddCardActionDestinationSpace(int spaceNumber)
        {
            _data.CardActionDestinationSpace = _spaces[spaceNumber];
        }
        
        public void EndRound()
        {
            _data.NumberOfTurn = _debugList.Count + 1;
            
            _debugList.Add(_data);

            _data = null;
        }

        public void PrintReport()
        {
            ConsoleTable.From(_debugList).Write();
        }
    }
}