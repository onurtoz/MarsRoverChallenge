using System;
using Common.Enums;
using Models;

namespace Services.RoverNavigate
{
    public class MoveNavigate : INavigate
    {
        public void Navigate(RoverPostion position)
        {
            switch (position.CurrentRoverDirectionPosition)
            {
                case DirectionType.N:
                    position.RoverYPosition += 1;
                    break;
                case DirectionType.S:
                    position.RoverYPosition -= 1;
                    break;
                case DirectionType.E:
                    position.RoverXPosition += 1;
                    break;
                case DirectionType.W:
                    position.RoverXPosition -= 1;
                    break;
                default:
                    break;
            }
        }
    }
}
