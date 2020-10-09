namespace Monopoly_Simulation.Model
{
    public class TurnResult
    {
        public AdditionalAction Action { get; set; }
    }

    public enum AdditionalAction
    {
        None,
        DrawGreenCard,
        DrawRedCard,
        GoToJail
    }
}