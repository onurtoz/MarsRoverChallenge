using Common.Enums;

namespace Models
{
    public class RoverPostion
    {
        public RoverPostion()
        {
            RoverXPosition = 0;
            RoverYPosition = 0;
            CurrentRoverDirectionPosition = DirectionType.N;
        }

        public int RoverXPosition { get; set; }

        public int RoverYPosition { get; set; }

        public DirectionType CurrentRoverDirectionPosition { get; set; }
    }
}
