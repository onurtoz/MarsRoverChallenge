using System;
using Common.Enums;
using Services.RoverNavigate;

namespace Services.Factory
{
    public class ConcreteNavigate : AbstractNavigate
    {
        protected INavigate roverNavigate = null;
        public override INavigate GetRoverNavigate(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.M:
                    roverNavigate = new MoveNavigate();
                    break;
                case CommandType.L:
                    roverNavigate = new LeftNavigate();
                    break;
                case CommandType.R:
                    roverNavigate = new RightNavigate();
                    break;
                default:
                    break;
            }
            return roverNavigate;
        }
    }
}
