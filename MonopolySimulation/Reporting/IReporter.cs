namespace Monopoly_Simulation.Reporting
{
    public interface IReporter
    {
        void StartRound();
        void AddInitialSpace(int spaceNumber);
        void AddRollResult(int eyes);
        void AddRollDestinationSpace(int spaceNumber);
        void AddSpaceAction(string action);
        void AddSpaceActionDestinationSpace(int spaceNumber);
        void AddCardAction(string action);
        void AddCardActionDestinationSpace(int spaceNumber);
        void EndRound();
        void PrintReport();
    }
}