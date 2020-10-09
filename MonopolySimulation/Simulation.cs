using System.Diagnostics;
using Monopoly_Simulation.Model;
using Monopoly_Simulation.Reporting;
using ShellProgressBar;

namespace Monopoly_Simulation
{
    public class Simulation 
    {
        private Gameboard _gameboard;
        private CardDeck _redCards;
        private CardDeck _greenCards;
        private Dice _dice;
        public IReporter Reporter { get; set; }

        public Simulation(Gameboard gameboard, CardDeck redCards, CardDeck greenCards, Dice dice, IReporter reporter)
        {
            _gameboard = gameboard;
            _redCards = redCards;
            _greenCards = greenCards;
            _dice = dice;
            Reporter = reporter;
        }

        public int NumberOfIterations { get; set; } = 1000;
        
        public void Simulate()
        {
            for (int i = 0; i < NumberOfIterations; i++)
            {  
                Reporter.StartRound();
                Reporter.AddInitialSpace(_gameboard.PositionOfPlayer);
                
                var eyes = _dice.Roll();
                Reporter.AddRollResult(eyes);
                
                var turnResult = _gameboard.MoveByDiceResult(eyes);
                Reporter.AddRollDestinationSpace(_gameboard.PositionOfPlayer);
                
                Reporter.AddSpaceAction(turnResult.Action.ToString());
                
                switch (turnResult.Action)
                {  
                    case AdditionalAction.GoToJail:
                        _gameboard.MoveToJail();
                        Reporter.AddSpaceActionDestinationSpace(_gameboard.PositionOfPlayer);
                        break;
                    
                    case AdditionalAction.DrawGreenCard:
                        DrawCard(_greenCards);
                        break;
                    
                    case AdditionalAction.DrawRedCard:
                        DrawCard(_redCards);
                        break;
                    
                    case AdditionalAction.None:
                        break;
                }
                
                Reporter.EndRound();
            }
        }

        private void DrawCard(CardDeck cardDeck)
        {
            Card newCard = cardDeck.Draw();
            Reporter.AddCardAction(newCard.Action.ToString());
            
            switch (newCard.Action)
            {
                case CardAction.MoveRelative:
                    _gameboard.MoveToRelativeTarget(newCard.Parameter);
                    break;
                
                case CardAction.NextSuperpower:
                    _gameboard.MoveToNextSuperpower();
                    break;
                
                case CardAction.NextVehicle:
                    _gameboard.MoveToNextVehicle();
                    break;
                
                case CardAction.GoToSpecificField:
                    _gameboard.MoveToSpecificSpace(newCard.Parameter);
                    break;
                
                case CardAction.None:
                    break;
            }
            Reporter.AddCardActionDestinationSpace(_gameboard.PositionOfPlayer);
        }
    }
}