using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tanaka.MarsRobot.HumanTechnology;
using Tanaka.MarsRobot.Universe;

namespace Tanaka.MarsRobot.Tests
{
    [TestClass]
    public class ExamSampleTest
    {
        private Planet mars;
        private Robot marsRover;

        public ExamSampleTest()
        {
            mars = new Planet(5, 5);
            marsRover = new Robot(mars, "North");
        }


        [TestMethod]
        public void TestCorrectCase()
        {
            marsRover.RunCommand("FFRFLFLF");
            Assert.AreEqual("1,4,West", string.Format("{0},{1},{2}", marsRover.PositionX, marsRover.PositionY, marsRover.FacingDirection));
        }

        [TestMethod]
        public void TestWrongCase()
        {
            marsRover.RunCommand("FRFLFRFLFLF");
            Assert.AreNotEqual("1,4,West", string.Format("{0},{1},{2}", marsRover.PositionX, marsRover.PositionY, marsRover.FacingDirection));
        }
    }
}
