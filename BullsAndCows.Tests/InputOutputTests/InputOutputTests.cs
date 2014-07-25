using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;
using System.IO;

namespace BullsAndCows.Tests.InputOutputTests
{
    [TestClass]
    public class InputOutputTests
    {
        [TestMethod]
        public void ShouldWriteCorrectMessageOnSingleLine()
        {
            InputOutput inputOutput = new InputOutput();            
            string expectedMessage = "Test message on a single line.";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string message = "Test message on a single line.";
                inputOutput.Write(message);
                Assert.AreEqual<string>(expectedMessage, sw.ToString());
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        [TestMethod]
        public void ShouldWriteCorrectMessageAndObjectOnSingleLine()
        {
            InputOutput inputOutput = new InputOutput();
            object testObject = new Object();
            string expectedMessage = string.Format("{0}", testObject);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string message = "{0}";
                inputOutput.Write(message, testObject);
                Assert.AreEqual<string>(expectedMessage, sw.ToString());
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        [TestMethod]
        public void ShouldWriteCorrectMessageOnNewLine()
        {
            InputOutput inputOutput = new InputOutput();
            string expectedMessage = "Test message on a new line.\r\n";            

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string message = "Test message on a new line.";
                inputOutput.WriteLine(message);
                Assert.AreEqual<string>(expectedMessage, sw.ToString());
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        [TestMethod]
        public void ShouldWriteCorrectMessageAndObjectOnNewLine()
        {
            InputOutput inputOutput = new InputOutput();
            object testObject = new Object();
            string expectedMessage = string.Format("{0}\r\n", testObject);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string message = "{0}";
                inputOutput.WriteLine(message, testObject);
                Assert.AreEqual<string>(expectedMessage, sw.ToString());
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        [TestMethod]
        public void ShouldWriteEmptyNewLine()
        {
            InputOutput inputOutput = new InputOutput();
            string expectedMessage = "\r\n";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                inputOutput.WriteLine();
                Assert.AreEqual<string>(expectedMessage, sw.ToString());
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }
    }
}