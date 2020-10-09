using System;

namespace Monopoly_Simulation.Model
{
    public class Card
    {
        public Guid Id { get; set; }

        public CardAction Action { get; set; }

        public string Parameter { get; set; }
    }
    
    public enum CardAction
    {
        None,
        GoToSpecificField,
        MoveRelative,
        NextSuperpower,
        NextVehicle
    }
}