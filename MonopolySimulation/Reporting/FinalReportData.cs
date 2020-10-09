using System;

namespace Monopoly_Simulation.Reporting
{
    public class FinalReportData : IComparable
    {
        public string SpaceName { get; set; }
        public decimal Probability { get; set; }
        
        public int CompareTo(object? obj)
        {
            FinalReportData other = obj as FinalReportData;

            if (this.Probability > other.Probability)
            {
                return 1;
            }
            
            if (other.Probability > this.Probability)
            {
                return -1;
            }
            
            return 0;
        }
    }
}