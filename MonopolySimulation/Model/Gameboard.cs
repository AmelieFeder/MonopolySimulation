using System;
using System.Collections.Generic;

namespace Monopoly_Simulation.Model
{
    public class Gameboard
    {
        private List<Space> _spaces;

        public Gameboard(List<Space> spaces)
        {
            _spaces = spaces;
        }

        public int PositionOfPlayer { get; set; }

        public TurnResult MoveByDiceResult(int eyes)
        {
            PositionOfPlayer = Move(eyes);

            AdditionalAction additionalAction = _spaces[PositionOfPlayer].Type.ToAdditionalAction();
            
            return new TurnResult
            {
                Action = additionalAction
            };
        }

        public TurnResult MoveToRelativeTarget(string target)
        {
            int relativeTargetMove = Int32.Parse(target);
            PositionOfPlayer = Move(relativeTargetMove);
            
            AdditionalAction additionalAction = _spaces[PositionOfPlayer].Type.ToAdditionalAction();
            
            return new TurnResult
            {
                Action = additionalAction
            };
        }

        public void MoveToJail()
        {
            PositionOfPlayer = 10;
        }

        public void MoveToSpecificSpace(string spaceName)
        {
            int n = -1;
            for (int i = 0; i < _spaces.Count; i++)
            {
                if (_spaces[i].Name == spaceName)
                {
                    n = i;
                    break;
                }
            }

            if (n == -1)
            {
                throw new InvalidOperationException($"ERROR: There is no space with name '{spaceName}'");
            }
            
            PositionOfPlayer = n;
        }

        public void MoveToNextSuperpower()
        {
            int n = -1;
            if (PositionOfPlayer >= 28)
            {
                PositionOfPlayer = 12;

                return;
            }
            
            for (int i = PositionOfPlayer; i < _spaces.Count; i++)
            {
                if (_spaces[i].Type == SpaceType.Superpower)
                {
                    n = i;
                    break;
                }
            }
            
            if (n == -1)
            {
                throw new InvalidOperationException($"ERROR: There is a problem with the superpowers!");
            }
            
            PositionOfPlayer = n;
        }

        public void MoveToNextVehicle()
        {
            int n = -1;
            if (PositionOfPlayer > 35)
            {
                PositionOfPlayer = 5;

                return;
            }
         
            for (int i = PositionOfPlayer; i < _spaces.Count; i++)
            {
                if (_spaces[i].Type == SpaceType.Vehicle)
                {
                    n = i;

                    break;
                }
            }
            
            if (n == -1)
            {
                throw new InvalidOperationException($"ERROR: There is a problem with the vehicles!");
            }
            
            PositionOfPlayer = n;
        }

        private int Move(int number)
        {
            int newNumber = PositionOfPlayer + number;
            
            if (newNumber > 39)
            {
                return PositionOfPlayer = PositionOfPlayer + number - 40;
            }
            
            if (newNumber < 0)
            {
               return PositionOfPlayer = PositionOfPlayer + number + 40;
            }
            
            return PositionOfPlayer = PositionOfPlayer + number;
        }
    }
}