namespace SupermarketQueue.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Globalization;
    using System.Threading;
    using System.IO;
    using System.Text;
    using System;

    [TestClass]
    public class SupermarketQueueTests
    {
        private void ExecuteTest(string inputFileName, string outputFileName)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var supermarketQueue = new SupermarketQueue();
            var inputCommands = File.ReadAllLines(@"..\..\..\SupermarketQueue-tests\" + inputFileName);
            var output = new StringBuilder();
            foreach (var command in inputCommands)
            {
                if (!string.IsNullOrEmpty(command))
                {
                    string commandResult = supermarketQueue.ProcessCommand(command);
                    if (commandResult != "End")
                    {
                        output.AppendLine(commandResult);
                    }
                }
            }
            var expectedOutput = File.ReadAllText(@"..\..\..\SupermarketQueue-tests\" + outputFileName);
            var actualOutput = output.ToString();

            Assert.AreEqual(expectedOutput.Trim(), actualOutput.Trim());
        }

        [TestMethod]
        public void Test_SampleInput()
        {
            ExecuteTest("test.000.001.in.txt", "test.000.001.out.txt");
        }

        [TestMethod]
        public void Test_000()
        {
            ExecuteTest("test.000.in.txt", "test.000.out.txt");
        }

        [TestMethod]
        public void Test_001()
        {
            ExecuteTest("test.001.in.txt", "test.001.out.txt");
        }

        [TestMethod]
        public void Test_002()
        {
            ExecuteTest("test.002.in.txt", "test.002.out.txt");
        }

        [TestMethod]
        public void Test_003()
        {
            ExecuteTest("test.003.in.txt", "test.003.out.txt");
        }

        [TestMethod]
        public void Test_004()
        {
            ExecuteTest("test.004.in.txt", "test.004.out.txt");
        }

        [TestMethod]
        public void Test_005()
        {
            ExecuteTest("test.005.in.txt", "test.005.out.txt");
        }

        [TestMethod]
        public void Test_006()
        {
            ExecuteTest("test.006.in.txt", "test.006.out.txt");
        }

        public void Test_007()
        {
            ExecuteTest("test.007.in.txt", "test.007.out.txt");
        }

        [TestMethod]
        public void Test_008()
        {
            ExecuteTest("test.008.in.txt", "test.008.out.txt");
        }

        [TestMethod]
        public void Test_009()
        {
            ExecuteTest("test.009.in.txt", "test.009.out.txt");
        }

        [TestMethod]
        public void Test_010()
        {
            ExecuteTest("test.010.in.txt", "test.010.out.txt");
        }

        [TestMethod]
        public void Test_011()
        {
            ExecuteTest("test.011.in.txt", "test.011.out.txt");
        }

        [TestMethod]
        public void Test_012()
        {
            ExecuteTest("test.012.in.txt", "test.012.out.txt");
        }

        [TestMethod]
        public void Test_013()
        {
            ExecuteTest("test.013.in.txt", "test.013.out.txt");
        }

        [TestMethod]
        public void Test_014()
        {
            ExecuteTest("test.014.in.txt", "test.014.out.txt");
        }

        [TestMethod]
        public void Test_015()
        {
            ExecuteTest("test.015.in.txt", "test.015.out.txt");
        }
    }
}
