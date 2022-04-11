using System;
using Common.Enums;
using Models;
using Services.Factory;

namespace Services.NavigateService
{
    public class RoverService: IRoverService
    {
        private readonly Plateau _plateau;

        private readonly AbstractNavigate _navgiateFactory;

        private ValidRover _validInstruction;

        public RoverService(AbstractNavigate navgiateFactory, Plateau plateau)
        {
            _plateau = plateau;
            _navgiateFactory = navgiateFactory;
            _validInstruction = new ValidRover();
        }

        public Rover PositionMove(Instruction instruction, Rover rover)
        {
           
            var validateInstruction = _validInstruction.IsValidInstruction(instruction, _plateau);
            if (validateInstruction.IsValid)
            {
                
                rover.RoverPostion.RoverXPosition = validateInstruction.XstartPositon;
                rover.RoverPostion.RoverYPosition = validateInstruction.YstartPosition;
                rover.RoverCommand = validateInstruction.RoverCommand;
                rover.RoverPostion.CurrentRoverDirectionPosition = validateInstruction.StartDirectionType;
                var rovercharcommmand = validateInstruction.RoverCommand.ToCharArray();
                foreach (var rovercommand in rovercharcommmand)
                {
                    try
                    {
                        Enum.TryParse(rovercommand.ToString(), out CommandType roverCommandType);
                        _navgiateFactory.GetRoverNavigate(roverCommandType).Navigate(rover.RoverPostion);
                    }
                    catch (Exception){ return null;}
                }
                bool overhead = rover.RoverPostion.RoverXPosition > _plateau.plateauSize[0] ? true : false || rover.RoverPostion.RoverYPosition > _plateau.plateauSize[1] ? true : false;
                return overhead == false ? rover : null;
            }
            else { return null; }


        }

       

    }
}
