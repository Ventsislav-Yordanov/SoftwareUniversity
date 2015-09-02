namespace RopeForEfficientStringEditing.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringEditorPerformanceTests
    {
        private const int MaxRuns = 5000000;

        [TestMethod]
        [Timeout(5000)]
        public void ManyInserts_ShouldPerformFastEnough()
        {
            var editor = new StringEditor();
            var stringToInsert = "abc";
            for (int i = 0; i < MaxRuns; i++)
            {
                editor.Insert(stringToInsert);
            }
        }

        [TestMethod]
        [Timeout(5000)]
        public void ManyAppends_ShouldPerformFastEnough()
        {
            var editor = new StringEditor();
            var stringToAppend = "abc";
            for (int i = 0; i < MaxRuns; i++)
            {
                editor.Append(stringToAppend);
            }
        }

        [TestMethod]
        [Timeout(5000)]
        public void ManyInsertsAppendsAndDeletes_ShouldPerformFastEnough()
        {
            var editor = new StringEditor();
            var value = "abc";
            for (int i = 0; i < MaxRuns / 4; i++)
            {
                editor.Insert(value);
                editor.Append(value);
                if (i != 0 && i % 4 == 0)
                {
                    editor.Delete(10, 1);
                }
            }
        }
    }
}
