using WonderGame;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BallTests
{
    [TestClass]
    public class BallTests
    {
        int size = 30;
        int height = 600;
        int width = 600;

        [TestMethod]
        public void BasicJump()
        {
            var lvl = new Level();
            for (var i = 0; i < (width / size); i++)
            {
                lvl.FirstFloor.Add(new Cell(true, false, Brushes.Brown));
                lvl.SecondFloor.Add(new Cell(true, false, Brushes.Brown));
            }
            var ballFir = new WonderBall(new Point(200, 230), size - 10, 0.9);
            var ballSec = new WonderBall(new Point(200, 480), size - 10, 0.9);

            Assert.AreEqual(lvl.CheckUnderTheBall(ballFir, size, height), true);
            Assert.AreEqual(lvl.FirstFloor[ballFir.X / size].IsDeath, false);
            Assert.AreEqual(lvl.CheckUnderTheBall(ballSec, size, height), true);
            Assert.AreEqual(lvl.SecondFloor[ballSec.X / size].IsDeath, false);
        }

        [TestMethod]
        public void BasicGoThrough()
        {
            var lvl = new Level();
            for (var i = 0; i < (width / size); i++)
            {
                lvl.FirstFloor.Add(new Cell(false, false, Brushes.Gray));
                lvl.SecondFloor.Add(new Cell(false, false, Brushes.Gray));
            }
            var ballFir = new WonderBall(new Point(200, 230), size - 10, 0.9);
            var ballSec = new WonderBall(new Point(200, 480), size - 10, 0.9);

            Assert.AreEqual(lvl.CheckUnderTheBall(ballFir, size, height), false);
            Assert.AreEqual(lvl.FirstFloor[ballFir.X / size].IsDeath, false);
            Assert.AreEqual(lvl.CheckUnderTheBall(ballSec, size, height), false);
            Assert.AreEqual(lvl.SecondFloor[ballSec.X / size].IsDeath, false);
        }

        [TestMethod]
        public void BasicDying()
        { 
            var lvl = new Level();
            for (var i = 0; i < (width / size); i++)
            {
                lvl.FirstFloor.Add(new Cell(true, true, Brushes.Red));
                lvl.SecondFloor.Add(new Cell(true, true, Brushes.Red));
            }
            var ballFir = new WonderBall(new Point(200, 230), size - 10, 0.9);
            var ballSec = new WonderBall(new Point(200, 480), size - 10, 0.9);

            Assert.AreEqual(lvl.CheckUnderTheBall(ballFir, size, height), true);
            Assert.AreEqual(lvl.FirstFloor[ballFir.X / size].IsDeath, true);
            Assert.AreEqual(lvl.CheckUnderTheBall(ballSec, size, height), true);
            Assert.AreEqual(lvl.SecondFloor[ballSec.X / size].IsDeath, true);
        }

        [TestMethod]
        public void DieFromCeiling()
        {
            var lvl = new Level();
            for (var i = 0; i < (width / size); i++)
            {
                lvl.FirstFloor.Add(new Cell(true, true, Brushes.Red));
                lvl.SecondFloor.Add(new Cell(true, false, Brushes.Brown));
            }
            var ball = new WonderBall(new Point(200, 260), size - 10, 0.9);

            Assert.AreEqual(lvl.CheckUpperTheBall(ball, size, height), true);
            Assert.AreEqual(lvl.FirstFloor[ball.X / size].IsDeath, true);
        }

        [TestMethod]
        public void PounceFromCeiling()
        {
            var lvl = new Level();
            for (var i = 0; i < (width / size); i++)
            {
                lvl.FirstFloor.Add(new Cell(true, false, Brushes.Brown));
                lvl.SecondFloor.Add(new Cell(true, false, Brushes.Brown));
            }
            var ball = new WonderBall(new Point(200, 260), size - 10, 0.9);

            Assert.AreEqual(lvl.CheckUpperTheBall(ball, size, height), true);
            Assert.AreEqual(lvl.FirstFloor[ball.X / size].IsDeath, false);
        }

        [TestMethod]
        public void GetThroughCeiling()
        {
            var lvl = new Level();
            for (var i = 0; i < (width / size); i++)
            {
                lvl.FirstFloor.Add(new Cell(false, false, Brushes.Gray));
                lvl.SecondFloor.Add(new Cell(false, false, Brushes.Gray));
            }
            var ball = new WonderBall(new Point(200, 260), size - 10, 0.9);

            Assert.AreEqual(lvl.CheckUpperTheBall(ball, size, height), false);
            Assert.AreEqual(lvl.FirstFloor[ball.X / size].IsDeath, false);
        }

    }
}
