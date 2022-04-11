using Common.Enums;
using Services.RoverNavigate;

namespace Services.Factory
{
   public abstract class AbstractNavigate
    {
        public abstract INavigate GetRoverNavigate(CommandType commandType);
    }
}
