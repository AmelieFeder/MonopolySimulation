using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using Monopoly_Simulation.Model;
using ShellProgressBar;

namespace Monopoly_Simulation.Reporting
{
    public class Reporter : IReporter
    {
        private Dictionary<int, ReportData> _report = new Dictionary<int, ReportData>();
        private int _iterations = 0;
        private List<Space> _spaces;

        private ProgressBar _progressBar;

        public Reporter(List<Space> spaces, ProgressBar progressBar)
        {
            _spaces = spaces;
            _progressBar = progressBar;
        }

        public void StartRound() { }

        public void AddInitialSpace(int spaceNumber) { }

        public void AddRollResult(int eyes) { }

        public void AddRollDestinationSpace(int spaceNumber)
        {
            AddOrUpdateProbability(spaceNumber);
        }
        
        public void AddSpaceAction(string action) { }

        public void AddSpaceActionDestinationSpace(int spaceNumber)
        {
            AddOrUpdateProbability(spaceNumber);
        }

        public void AddCardAction(string action) { }

        public void AddCardActionDestinationSpace(int spaceNumber)
        {
            AddOrUpdateProbability(spaceNumber);
        }

        public void EndRound()
        {
            _iterations++;
            _progressBar.Tick();
        }

        public void PrintReport()
        {
            Console.Clear();
            Console.WriteLine($"The simulation was run with {_iterations} dice rolls.");

            List<FinalReportData> finalReport = new List<FinalReportData>();
            
            foreach (int key in _report.Keys)
            {
                finalReport.Add(new FinalReportData
                {
                    SpaceName = _report[key].SpaceName,
                    Probability = _report[key].Visits / _iterations * 100
                });
            }

            finalReport = finalReport
                .Where(r => r.SpaceName != "Jail")
                .Where(r => r.SpaceName != "Smaaash")
                .Where(r => r.SpaceName != "Thooom")
                .Where(r => r.SpaceName != "Los")
                .ToList();
            
            finalReport.Sort((a, b) => b.CompareTo(a));
            
            ConsoleTable.From(finalReport).Configure(o => o.EnableCount = false).Write();
        }
        
        private void AddOrUpdateProbability(int spaceNumber)
        {
            if (!_report.ContainsKey(spaceNumber))
            {
                string name = _spaces[spaceNumber].Name;
                
                _report.Add(spaceNumber, new ReportData
                {
                    SpaceName = name,
                    Visits = 0
                });
            }

            _report[spaceNumber].Visits++;
        }
    }
}