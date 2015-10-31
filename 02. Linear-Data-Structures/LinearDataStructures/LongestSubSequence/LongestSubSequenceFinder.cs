namespace LongestSubSequence
{
    using System.Collections.Generic;

    public class LongestSubSequenceFinder
    {
        public List<int> FindLongestSubsequence(List<int> list)
        {
            if (list == null || list.Count == 0)
            {
                return new List<int>();
            }

            if (list.Count == 1)
            {
                return new List<int> { list[0] };
            }

            int currentSequenceStart = 0;
            int currentSequenceLength = 1;
            int longestSequenceStart = 0;
            int longestSequenceLength = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] == list[i])
                {
                    ++currentSequenceLength;
                }
                else
                {
                    currentSequenceStart = i;
                    currentSequenceLength = 1;
                }

                if (currentSequenceLength <= longestSequenceLength)
                {
                    continue;
                }

                longestSequenceStart = currentSequenceStart;
                longestSequenceLength = currentSequenceLength;
            }

            return list.GetRange(longestSequenceStart, longestSequenceLength);
        }
    }
}