using Monopoly_Simulation.Model;

namespace Monopoly_Simulation.Reporting
{
    public class DebugReportData
    {
        public int NumberOfTurn { get; set; }
        public Space InitialSpace { get; set; }
        public int RollResult { get; set; }
        public Space RollDestinationSpace { get; set; }
        public string SpaceAction { get; set; }
        public Space SpaceActionDestinationSpace { get; set; } = Space.Default();
        public string CardAction { get; set; } = "None";
        public Space CardActionDestinationSpace { get; set; } = Space.Default();
        
    }
}