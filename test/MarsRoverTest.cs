using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services.Factory;
using Services.NavigateService;

namespace UnitTest
{
    [TestClass]
    public class MarsRoverTest
    {
        private Plateau plateau;
        private RoverPostion position;
        private AbstractNavigate navgiateFactory;
        private RoverService roverService;
        private Instruction instruction;
        private Rover rover;


        [TestInitialize]
        public void Init()
        {
            plateau = new Plateau();
            position = new RoverPostion();
            navgiateFactory = new ConcreteNavigate();
            instruction = new Instruction();
            rover = new Rover();
        }


        [TestMethod]
        public void NavigateTest_12N_LMLMLMLMM()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };
            roverService = new RoverService(navgiateFactory, plateau);
            instruction.messages = new List<string>() { "1 2 N", "LMLMLMLMM" };
            rover.RoverId = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            var actualOutput = $"{rover.RoverPostion.RoverXPosition} {rover.RoverPostion.RoverYPosition} {rover.RoverPostion.CurrentRoverDirectionPosition.ToString()}";
            var expectedOutput = "1 3 N";
            Assert.AreEqual(expectedOutput, actualOutput);


        }

        [TestMethod]
        public void NavigateTest_33E_MMRMMRMRRM()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };
            roverService = new RoverService(navgiateFactory, plateau);
            instruction.messages = new List<string>() { "3 3 E", "MMRMMRMRRM" };
            rover.RoverId = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            var actualOutput = $"{rover.RoverPostion.RoverXPosition} {rover.RoverPostion.RoverYPosition} {rover.RoverPostion.CurrentRoverDirectionPosition.ToString()}";
            var expectedOutput = "5 1 E";
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void NavigateTest_GreaterRoverPositionThanPlateau()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.messages = new List<string>() { "6 6 E", "MMRMMRMRRM" };
            rover.RoverId = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }


        [TestMethod]
        public void NavigateTest_GreaterRoverPositionAfterPostionMoveThanPlateau()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.messages = new List<string>() { "5 5 N", "MMRMMRMRRM" };
            rover.RoverId = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }




        [TestMethod]
        public void NavigateTest_InvalidCharactersofCommmand()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.messages = new List<string>() { "1 2 N", "TTRMMRMRRM" };
            rover.RoverId = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }


        [TestMethod]
        public void NavigateTest_InvalidCharactersofPositionX()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.messages = new List<string>() { " 2 N", "LMLMLMLMM" };
            rover.RoverId = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }


        [TestMethod]
        public void NavigateTest_InvalidCharactersofPositionY()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.messages = new List<string>() { "2  N", "LMLMLMLMM" };
            rover.RoverId = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }


        [TestMethod]
        public void NavigateTest_InvalidSplitOfMessage()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.messages = new List<string>() { "12N", "LMLMLMLMM" };
            rover.RoverId = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }

        [TestMethod]
        public void NavigateTest_InvalidEmptyOfMessageandCommand()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.messages = new List<string>() { "", "" };
            rover.RoverId = Guid.NewGuid();
            rover.RoverPostion = position;

            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }
    }
}
