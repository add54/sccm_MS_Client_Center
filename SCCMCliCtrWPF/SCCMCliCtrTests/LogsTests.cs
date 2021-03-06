using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientCenter.Logs;
using System;

namespace ClientCenter.Tests
{
    [TestClass()]
    public class LogsTests
    {
        [TestMethod()]
        public void TestCMLogParsing()
        {
            string cmLogLine = "<![LOG[BEGIN ExecuteSystemTasks('PowerChanged')]LOG]!><time=\"07:57:18.385+00\" date=\"01-02-2018\" component=\"CcmExec\" context=\"\" type=\"1\" thread=\"14600\" file=\"systemtask.cpp:581\">";
            LogEntry cmParsingResult = LogEntry.ParseLogLine(cmLogLine);
            Assert.AreEqual("BEGIN ExecuteSystemTasks('PowerChanged')", cmParsingResult.LogText);
            Assert.AreEqual("CcmExec", cmParsingResult.Component);
            Assert.AreEqual(new DateTime(2018, 01, 02, 07, 57, 18, 385), cmParsingResult.Date);
        }

        [TestMethod()]
        public void TestWULogParsing()
        {
            string wuLogLine = "2017-12-04\t08:08:48:990\t488\tf48\tAU\tWARNING: There are no approved updates to install";
            LogEntry wuParsingResult = LogEntry.ParseLogLine(wuLogLine);
            Assert.AreEqual("WARNING: There are no approved updates to install", wuParsingResult.LogText);
            Assert.AreEqual("AU", wuParsingResult.Component);
            Assert.AreEqual(new DateTime(2017, 12, 04, 08, 08, 48, 990), wuParsingResult.Date);
        }
    }
}
