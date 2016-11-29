using JustMockingAround;
using JustMockingAround.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.JustMock;

namespace JustMockingAround.Tests
{
    [TestClass]
    public class ProgramTests : ProgramTestsBase
    {
        private Program _program;

        private Program Program
        {
            get
            {
                return _program ?? (_program = new Program());
            }
        }

        [TestMethod]
        public void Program_DoStuffWithBytes_SavesData()
        {
            var bytes = new byte[8];

            Program.DoStuffWithBytes(bytes);

            Mock.Assert(() => Dependency.SaveData(bytes, Arg.AnyDateTime));
        }

        [TestMethod]
        public void Program_DoStuffInternal_ReturnsCalculation1IfTotalIsUnder10()
        {
            int total = 9;
            int calculation = 50;

            Mock.Arrange(() => Dependency.GetCalculation1(total)).Returns(calculation);

            var result = Program.DoStuffInternal(total);

            Assert.AreEqual(calculation, result);
        }

        #region JustMock Full Required

        [TestMethod]
        public void Program_CalculateResultsAndAdd10_CallsDoStuffInternalWithTotal()
        {
            int total = 10;

            // Internal method must be arranged before it can be asserted on
            Mock.Arrange(() => Program.DoStuffInternal(total)).DoNothing();

            var result = Program.CalculateResultAndAdd10(total);

            Mock.Assert(() => Program.DoStuffInternal(total));
        }

        [TestMethod]
        public void Program_CalculateResultAndAdd10_Adds10ToCalculation()
        {
            int calculation = 500;
            int calculationPlus10 = 510;

            Mock.Arrange(() => Program.DoStuffInternal(Arg.AnyInt)).Returns(calculation);

            var result = Program.CalculateResultAndAdd10(default(int));

            Assert.AreEqual(calculationPlus10, result);
        }

        [TestMethod]
        public void Program_DoStuffInternal_UsesCalculation1IfTotalIsUnder10()
        {
            int total = 9;

            Program.DoStuffInternal(total);

            Mock.Assert(() => Dependency.GetCalculation1(total));
        }

        [TestMethod]
        public void Program_DoStuffInternal_UsesCalculation2IfTotalIsOver9()
        {
            int total = 10;

            Program.DoStuffInternal(total);

            Mock.Assert(() => Dependency.GetCalculation2(total));
        }

        [TestMethod]
        public void Program_DoStuffWithBytes_LogsBytesSavingMessage()
        {
            Program.DoStuffWithBytes(default(byte[]));

            Mock.Assert((() => Logger.Log("Saved the bytes!")));
        }

        [TestMethod]
        public void Program_DoStuffWithBytes_SavesWithUtcNowTimestamp()
        {
            var utcNow = DateTime.UtcNow;

            Mock.Arrange(() => DateTime.UtcNow).Returns(utcNow);

            Program.DoStuffWithBytes(default(byte[]));

            Mock.Assert(() => Dependency.SaveData(Arg.IsAny<byte[]>(), utcNow));
        }

        #endregion
    }
}