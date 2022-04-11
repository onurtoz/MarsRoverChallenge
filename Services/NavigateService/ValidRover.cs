using System;
using Common.Enums;
using Models;

namespace Services.NavigateService
{
    public class ValidRover
    {

        private ValidateInstruction _manipulateInstruction;

        public ValidRover()
        {
            _manipulateInstruction = new ValidateInstruction();
        }
       
        public ValidateInstruction IsValidInstruction(Instruction instruction ,Plateau plateau)
        {
            if (instruction.messages.Count == 0 || instruction.messages.Count != 2 || instruction.messages[0].Split(' ').Length != 3)
            {

                _manipulateInstruction.IsValid = false;
                return _manipulateInstruction;
            }

            var roverPostionLocation = instruction.messages[0].Split(' ');
            var roverCommand = instruction.messages[1];
            var nullcontrol = roverPostionLocation[0] == "" ? true : false || roverPostionLocation[1] == "" ? true : false || roverPostionLocation[2] == "" ? true : false;
            if (nullcontrol) {_manipulateInstruction.IsValid = false; return _manipulateInstruction;}

            int.TryParse(roverPostionLocation[0], out var roverxStartPosition);
            int.TryParse(roverPostionLocation[1], out var roveryStartPostion);
            Enum.TryParse(roverPostionLocation[2], out DirectionType roverDirection);

          if(!IsValidPlateau(plateau, roverxStartPosition, roveryStartPostion)) { _manipulateInstruction.IsValid = false; return _manipulateInstruction;}

            _manipulateInstruction.IsValid = true;
            _manipulateInstruction.StartDirectionType = roverDirection;
            _manipulateInstruction.XstartPositon = roverxStartPosition;
            _manipulateInstruction.YstartPosition = roveryStartPostion;
            _manipulateInstruction.RoverCommand = roverCommand;

            return _manipulateInstruction;
        }


        public bool IsValidPlateau(Plateau plateau ,int roverXposition , int roverYposition)
        {
              var result = true;
            if (plateau.plateauSize.Count != 2 || plateau.plateauSize[0] < roverXposition || plateau.plateauSize[1] < roverYposition)
                result = false;
            return result;
        }
    }

   
}
