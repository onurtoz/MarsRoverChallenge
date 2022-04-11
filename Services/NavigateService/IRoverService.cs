using System;
using Models;

namespace Services.NavigateService
{
    public interface IRoverService
    {
        Rover PositionMove(Instruction ınstruction, Rover rover);
    }
}
