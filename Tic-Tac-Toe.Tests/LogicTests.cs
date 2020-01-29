using LogicLibrary;
using NUnit.Framework;

namespace Tic_Tac_Toe.Tests
{
    [TestFixture]
    public class LogicTests
    {
        GameEngine gameEngine;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            gameEngine = new GameEngine();

            gameEngine.UpdateState("01");

            Assert.AreEqual(0, gameEngine.row);

            Assert.AreEqual(1, gameEngine.column);
        }
    }
}