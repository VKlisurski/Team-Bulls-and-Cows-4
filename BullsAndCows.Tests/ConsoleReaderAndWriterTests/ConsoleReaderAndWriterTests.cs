using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;
using System.IO;
using BullsAndCowsGame.Contracts;

namespace BullsAndCows.Tests.ConsoleReaderAndWriterTests
{
    [TestClass]
    public class ConsoleReaderAndWriterTests
    {
        [TestMethod]
        public void ShouldWriteCorrectMessageOnSingleLine()
        {
            IPrinter printer = new ConsolePrinter();            
            string expectedMessage = "Test message on a single line.";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string message = "Test message on a single line.";
                printer.Write(message);
                Assert.AreEqual<string>(expectedMessage, sw.ToString());
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        [TestMethod]
        public void ShouldWriteCorrectMessageOnNewLine()
        {
            IPrinter printer = new ConsolePrinter();
            string expectedMessage = "Test message on a new line.\r\n";            

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string message = "Test message on a new line.";
                printer.WriteLine(message);
                Assert.AreEqual<string>(expectedMessage, sw.ToString());
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        [TestMethod]
        public void ShouldWriteEmptyNewLine()
        {
            IPrinter printer = new ConsolePrinter();
            string expectedMessage = "\r\n";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                printer.WriteLine();
                Assert.AreEqual<string>(expectedMessage, sw.ToString());
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }
        

        [TestMethod]
        public void ShouldReadOneLineOfCharacters()
        {
            IReader reader = new ConsoleReader();
            string expectedMessage = "test message";

            using (StringReader sr = new StringReader("test message"))
            {
                Console.SetIn(sr);

                string fromReader = reader.ReadLine();

                Assert.AreEqual<string>(expectedMessage, fromReader);
                Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            }
        }
    }
}