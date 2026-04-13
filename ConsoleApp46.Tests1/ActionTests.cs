using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp46;

namespace ConsoleApp46.Tests1
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void SwitchCasing_WhenWPressed_ChangesCoordinates()
        {
            // Arrange
            int i = 0;
            int j = 0;
            var key = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

            // Act
            Action.SwitchCasing(key, ref i, ref j);

            // Assert
            Assert.AreNotEqual(0, i + j);
        }

        [TestMethod]
        public void SwitchCasing_WhenAPressed_ChangesCoordinates()
        {
            // Arrange
            int i = 0;
            int j = 0;
            var key = new ConsoleKeyInfo('a', ConsoleKey.A, false, false, false);

            // Act
            Action.SwitchCasing(key, ref i, ref j);

            // Assert
            Assert.AreNotEqual(0, i + j);
        }

        [TestMethod]
        public void SwitchCasing_WhenSPressed_ChangesCoordinates()
        {
            // Arrange
            int i = 0;
            int j = 0;
            var key = new ConsoleKeyInfo('s', ConsoleKey.S, false, false, false);

            // Act
            Action.SwitchCasing(key, ref i, ref j);

            // Assert
            Assert.AreNotEqual(0, i + j);
        }

        [TestMethod]
        public void SwitchCasing_WhenDPressed_ChangesCoordinates()
        {
            // Arrange
            int i = 0;
            int j = 0;
            var key = new ConsoleKeyInfo('d', ConsoleKey.D, false, false, false);

            // Act
            Action.SwitchCasing(key, ref i, ref j);

            // Assert
            Assert.AreNotEqual(0, i + j);
        }
    }
}
