using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using Pacman.Processor;
using Pacman.Entities;
using Pacman.Services;
using Pacman.Parser;

namespace Pacman.UnitTest
{
    [TestClass]
    public class EdgeCaseTestScenarios
    {
        public static string GetRootPath()
        {
            string rootPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\TestCaseFiles"));
            return rootPath;
        }

        private CommandParser commandParser;
        private IEngine engine;
        public EdgeCaseTestScenarios()
        {

            engine = new PacmanEngine();
        }


        /// <summary>
        /// When Pacman is positioned at SOUTH WEST most corner
        /// And multiple move commands executed 
        /// Pacman remains in the same position
        /// </summary>
        [TestMethod]
        public void Test1()
        {
            //Arrange 
            commandParser = new FileParser(Path.Combine(GetRootPath(), "SouthWestCorner.txt"));

            List<string> textCommands = commandParser.GetTextCommands();
            List<ICommand> commands = commandParser.Parse();

            //Act 
            Coordinate currentPoint = engine.Manoeuvre(commands);
            string currentPosition = engine.Report(currentPoint);

            //Assert
            Assert.AreEqual(textCommands.First().Split(" ")[1], currentPosition);
        }


        /// <summary>
        /// When few commands issued & no place command found 
        ///Console shows error message 
        /// </summary>
        [TestMethod]
        public void Test2()
        {
            commandParser = new FileParser(Path.Combine(GetRootPath(), "NoPlaceCommand.txt"));
            List<string> textCommands = commandParser.GetTextCommands();
            List<ICommand> commands = commandParser.Parse();

            Assert.ThrowsException<InvalidOperationException>(() => engine.Manoeuvre(commands));
        }

        /// <summary>
        /// When few commands issueed & first command is not the Place command
        /// All the commands before Place command are ignored
        /// </summary>
        [TestMethod]
        public void Test3()
        {
            commandParser = new FileParser(Path.Combine(GetRootPath(), "MiddlePlaceCommand.txt"));
            List<ICommand> commands = commandParser.Parse();

            Coordinate currentPoint = engine.Manoeuvre(commands);

            Assert.AreEqual(0, currentPoint.X);
            Assert.AreEqual(3, currentPoint.Y);
            Assert.AreEqual(Position.West, currentPoint.Position);
        }

        /// <summary>
        /// When Pacman is at the top most right corner of the tabletop
        /// it will ignore the rest of 'Move' commands and remains in its position 
        /// </summary>
        [TestMethod]
        public void Test4()
        {
            //Arrange 
            commandParser = new FileParser(Path.Combine(GetRootPath(), "TopEastCorner.txt"));

            List<string> textCommands = commandParser.GetTextCommands();
            List<ICommand> commands = commandParser.Parse();

            //Act 
            Coordinate currentPoint = engine.Manoeuvre(commands);
            string currentPosition = engine.Report(currentPoint);

            //Assert
            Assert.AreEqual(textCommands.First().Split(" ")[1].ToUpper(), currentPosition.ToUpper());
        }

        /// <summary>
        /// When Few commands executed and one of command is invalid
        /// console shows error message 
        /// </summary>
        [TestMethod]
        public void Test5()
        {

            commandParser = new FileParser(Path.Combine(GetRootPath(), "InvalidCommand.txt"));
            List<string> textCommands = commandParser.GetTextCommands();
            List<ICommand> commands = commandParser.Parse();

           var ex= Assert.ThrowsException<InvalidOperationException>(() => engine.Manoeuvre(commands));
            Assert.IsTrue(ex.Message.StartsWith("The specified command or list of commands are invalid"));
        }

    }
}
