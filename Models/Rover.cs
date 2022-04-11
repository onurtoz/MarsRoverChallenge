using System;

namespace Models
{
    public class Rover
    {
        public Guid RoverId { get; set; }

        public RoverPostion RoverPostion { get; set; }

        public string RoverCommand { get; set; }
    }
}
