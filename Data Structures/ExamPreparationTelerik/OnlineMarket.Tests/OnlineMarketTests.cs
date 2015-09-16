namespace OnlineMarket.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using System.Globalization;
    using System.IO;
    using System.Text;

    [TestClass]
    public class OnlineMarketTests
    {
        private void ExecuteTest(string inputFileName, string outputFileName)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var market = new OnlineMarket();
            var inputCommands = File.ReadAllLines(@"..\..\..\OnlineMarket-tests\" + inputFileName);
            var output = new StringBuilder();
            foreach (var command in inputCommands)
            {
                if (!string.IsNullOrEmpty(command))
                {
                    string commandResult = market.ProcessCommand(command);
                    if (commandResult != "End")
                    {
                        output.AppendLine(commandResult);
                    }
                }
            }

            var expectedOutput = File.ReadAllText(@"..\..\..\OnlineMarket-tests\" + outputFileName);
            var actualOutput = output.ToString();

            Assert.AreEqual(expectedOutput.Trim(), actualOutput.Trim());
        }

        [TestMethod]
        public void Test_SampleInput()
        {
            ExecuteTest("test.000.001.in.txt", "test.000.001.out.txt");
        }

        [TestMethod]
        public void Test_SampleInput2()
        {
            ExecuteTest("test.000.002.in.txt", "test.000.002.out.txt");
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
    }
}
