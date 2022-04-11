using System;
using Common.Enums;
using Models;

namespace Services.RoverNavigate
{
    public class RightNavigate : INavigate
    {
        public void Navigate(RoverPostion position)
        {
            switch (position.CurrentRoverDirectionPosition)
            {
                case DirectionType.N:
                    position.CurrentRoverDirectionPosition = DirectionType.E;
                    break;
                case DirectionType.E:
                    position.CurrentRoverDirectionPosition = DirectionType.S;
                    break;

                case DirectionType.S:
                    position.CurrentRoverDirectionPosition = DirectionType.W;
                    break;

                case DirectionType.W:
                    position.CurrentRoverDirectionPosition = DirectionType.N;
                    break;
            }
        }
    }
}
