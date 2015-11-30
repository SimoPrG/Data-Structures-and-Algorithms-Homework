namespace LongestSubSequence.Te
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using LongestSubSequence;

    [TestClass]
    public class UnitTestFindLongestSubsequence
    {
        private readonly LongestSubSequenceFinder finder = new LongestSubSequenceFinder();

        [TestMethod]
        public void ExpectFindLongestSubsequenceToReturnEmptyListWhenPassedNull()
        {
            var result = this.finder.FindLongestSubsequence(null);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ExpectFindLongestSubsequenceToReturnEmptyListWhenPassedEmtyList()
        {
            var result = this.finder.FindLongestSubsequence(new List<int>());
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ExpectFindLongestSubsequenceToReturnCorrectResultWhenPassedListWithOneElement()
        {
            var result = this.finder.FindLongestSubsequence(new List<int>() {1});
            Assert.AreEqual(1, result.Count, "The count is not correct");
            Assert.AreEqual(1, result[0], "The result is not correct");
        }

        [TestMethod]
        public void ExpectFindLongestSubsequenceToReturnCorrectResultWhenPassedListWithLongestSubSequenceInTheBeginning()
        {
            var result = this.finder.FindLongestSubsequence(new List<int>() { 1, 1, 0, -1 });
            Assert.AreEqual(2, result.Count, "The count is not correct");
            Assert.AreEqual(1, result[0], "The result is not correct");
            Assert.AreEqual(1, result[1], "The result is not correct");
        }

        [TestMethod]
        public void ExpectFindLongestSubsequenceToReturnCorrectResultWhenPassedListWithLongestSubSequenceInTheMiddle()
        {
            var result = this.finder.FindLongestSubsequence(new List<int>() { 0, 1, 1, -1 });
            Assert.AreEqual(2, result.Count, "The count is not correct");
            Assert.AreEqual(1, result[0], "The result is not correct");
            Assert.AreEqual(1, result[1], "The result is not correct");
        }

        [TestMethod]
        public void ExpectFindLongestSubsequenceToReturnCorrectResultWhenPassedListWithLongestSubSequenceInTheEnd()
        {
            var result = this.finder.FindLongestSubsequence(new List<int>() { 0, -1, 1, 1 });
            Assert.AreEqual(2, result.Count, "The count is not correct");
            Assert.AreEqual(1, result[0], "The result is not correct");
            Assert.AreEqual(1, result[1], "The result is not correct");
        }
    }
}