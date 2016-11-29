using JustMockingAround.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace JustMockingAround.Tests
{
    [TestClass]
    public class LoggerTests
    {
        #region JustMock Full Required

        [TestMethod]
        public void Logger_WriteMessageToConsole()
        {
            var message = "message";

            Mock.Arrange(() => Console.WriteLine(Arg.AnyString)).CallOriginal();

            Logger.Log(message);

            Mock.Assert(() => Console.WriteLine(message));
        }

        #endregion
    }
}
