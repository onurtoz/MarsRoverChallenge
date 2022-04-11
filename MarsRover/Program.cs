using System;
using System.Collections.Generic;
using ConsoleTables;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Services.Factory;
using Services.NavigateService;

namespace MarsRover
{
    class Program
    {

        static void Main(string[] args)
        {


            var roverStartPosition = new ConsoleTable("RoverID", "RoverXPostion", "RoverYPostion", "RoverCurrentDirection");


            #region Input Example

            Plateau plateau = new Plateau();
            plateau.plateauSize.Add(5);
            plateau.plateauSize.Add(5);

            List<Instruction> instructions = new List<Instruction>();
            Instruction instruction1 = new Instruction();
            instruction1.messages.Add("1 2 N");
            instruction1.messages.Add("LMLMLMLMM");

            Instruction instruction2 = new Instruction();
            instruction2.messages.Add("3 3 E");
            instruction2.messages.Add("MMRMMRMRRM");

            instructions.Add(instruction1);
            instructions.Add(instruction2);

            RoverPostion roverPosition = new RoverPostion();
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover()
            {

                RoverId = Guid.NewGuid(),
                RoverPostion = roverPosition,
                RoverCommand ="",
                
            });
            rovers.Add(new Rover()
            {

                RoverId = Guid.NewGuid(),
                RoverPostion = roverPosition,
                RoverCommand ="",
             
            });

            #endregion

            #region injection
            var serviceProvider = new ServiceCollection()
           .AddSingleton<AbstractNavigate, ConcreteNavigate>()
           .AddSingleton<IRoverService, RoverService>()
           .AddSingleton<Plateau>(plateau)
         .BuildServiceProvider();

            IRoverService provider = serviceProvider.GetService<IRoverService>();

            #endregion


            for (int i = 0; i < rovers.Count; i++)
            {
                rovers[i] = provider.PositionMove(instructions[i], rovers[i]);
                if (rovers[i] != null)
                    roverStartPosition.AddRow(rovers[i].RoverId, rovers[i].RoverPostion.RoverXPosition, rovers[i].RoverPostion.RoverYPosition, rovers[i].RoverPostion.CurrentRoverDirectionPosition);
            }

            Console.WriteLine(roverStartPosition);
            Console.ReadLine();
        }
    }
}
