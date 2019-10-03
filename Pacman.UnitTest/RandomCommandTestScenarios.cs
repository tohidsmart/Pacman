using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Entities;
using Pacman.Services;
using Pacman.Parser;
using Pacman.Processor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pacman.UnitTest
{
    [TestClass]
    public class RandomCommandTestScenarios
    {
        public static string GetRootPath()
        {
            string rootPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\TestCaseFiles"));
            return rootPath;
        }

        private CommandParser commandParser;
        private IEngine engine;
         public RandomCommandTestScenarios()
        {
            engine = new PacmanEngine();
        }
        
        /// <summary>
        /// The commands comes from Scenario1.txt file
        /// Given pacman is Placed on  2,3,North
        ///then commands are executed :  Move, Move, Left,Move,Left,Move
        /// Final position would be 1,4,South
        /// </summary>
        [TestMethod]
        public void ScenarioOne()
        {
            commandParser = new FileParser(Path.Combine(GetRootPath(), "Scenario1.txt"));
            List<ICommand> commands = commandParser.Parse();

            Coordinate currentCoordinate= engine.Manoeuvre(commands);
            Coordinate expectedCoordinate = new Coordinate
            {
                X = 1,
                Y = 4,
                Position = Position.South
            };

            Assert.AreEqual(expectedCoordinate.X, currentCoordinate.X);
            Assert.AreEqual(expectedCoordinate.Y, currentCoordinate.Y);
            Assert.AreEqual(expectedCoordinate.Position, currentCoordinate.Position);
        }

        /// <summary>
        /// The commands comes from Scenario2.txt file
        /// Given pacman is placed on 4,5,West
        /// When pacman rotates to  left, left, left
        /// The coordinate remain the same but robot changes facing-location
        /// </summary>
        [TestMethod]
        public void ScenarioTwo()
        {
            commandParser = new FileParser(Path.Combine(GetRootPath(), "Scenario2.txt"));
            List<ICommand> commands = commandParser.Parse();

            Coordinate currentCoordinate = engine.Manoeuvre(commands);
            Coordinate expectedCoordinate = new Coordinate
            {
                X = 4,
                Y = 5,
                Position = Position.North
            };

            Assert.AreEqual(expectedCoordinate.X, currentCoordinate.X);
            Assert.AreEqual(expectedCoordinate.Y, currentCoordinate.Y);
            Assert.AreEqual(expectedCoordinate.Position, currentCoordinate.Position);
        }


        /// <summary>
        /// The commands comes from Scenario3.txt file
        /// Given Pacman is placed on 3,2,South
        /// When Pacman is re-positioned into new location : 2,2,North
        /// it starts to manoeuvre from new position : 
        /// </summary>
        [TestMethod]
        public void ScenarioThree()
        {
            commandParser = new FileParser(Path.Combine(GetRootPath(), "Scenario3.txt"));
            List<ICommand> commands = commandParser.Parse();

            Coordinate currentCoordinate = engine.Manoeuvre(commands);
            Coordinate expectedCoordinate = new Coordinate
            {
                X = 2,
                Y = 3,
                Position = Position.North
            };

            Assert.AreEqual(expectedCoordinate.X, currentCoordinate.X);
            Assert.AreEqual(expectedCoordinate.Y, currentCoordinate.Y);
            Assert.AreEqual(expectedCoordinate.Position, currentCoordinate.Position);
        }

    }
}
