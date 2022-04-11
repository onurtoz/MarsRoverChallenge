using System;
using Common.Enums;
using Models;

namespace Services.RoverNavigate
{
    public class LeftNavigate : INavigate
    {
        public void Navigate(RoverPostion position)
        {
            switch (position.CurrentRoverDirectionPosition)
            {
                case DirectionType.N:
                    position.CurrentRoverDirectionPosition = DirectionType.W;
                    break;
                case DirectionType.E:
                    position.CurrentRoverDirectionPosition = DirectionType.N;
                    break;

                case DirectionType.S:
                    position.CurrentRoverDirectionPosition = DirectionType.E;
                    break;

                case DirectionType.W:
                    position.CurrentRoverDirectionPosition = DirectionType.S;
                    break;
            }
        }
    }
}
