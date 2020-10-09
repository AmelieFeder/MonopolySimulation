namespace Monopoly_Simulation.Model
{
    public class Space
    {
        public string Name { get; set; }
        private int PositionOnBoard { get; set; }
        public SpaceType Type { get; set; }

        public static Space Default()
        {
            return new Space
            {
                Name = "-",
                PositionOnBoard = -1,
                Type = SpaceType.None
            };
        }

        public override string ToString()
        {
            if (PositionOnBoard == -1)
            {
                return "-";
            }
            else
            {
                return $"{PositionOnBoard} - {Name}";
            }
        }
    }

    public enum SpaceType
    {
        Comic,
        Vehicle,
        Superpower,
        Jail,
        DrawRedCard,
        DrawGreenCard,
        GoToJail,
        None
    }

    public static class SpaceTypeExtensions
    {
        public static AdditionalAction ToAdditionalAction(this SpaceType spaceType)
        {
            switch (spaceType)
            {
                case SpaceType.DrawGreenCard:
                    return AdditionalAction.DrawGreenCard;
                case SpaceType.DrawRedCard:
                    return AdditionalAction.DrawRedCard;
                case SpaceType.GoToJail:
                    return AdditionalAction.GoToJail;
                default:
                    return AdditionalAction.None;
            }
        }
    }
}