using System;
using Common.Enums;

namespace Models
{
    public class ValidateInstruction
    {
        public bool IsValid { get; set; }
        public int XstartPositon { get; set; }
        public int YstartPosition { get; set; }
        public DirectionType StartDirectionType { get; set; }
        public string RoverCommand { get; set; }

    }
}
