using System;
using Models;
namespace Services.RoverNavigate
{
    public interface INavigate
    {
        void Navigate(RoverPostion position);
    }
}
