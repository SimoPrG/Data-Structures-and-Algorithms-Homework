namespace NegativeNumbers
{
    using System.Collections.Generic;
    using System.Linq;

    public class NegativeNumbersRemover
    {
        public IEnumerable<int> RemoveNegativeNumbers(IEnumerable<int> input)
        {
            return input.Where(n => n >= 0).ToList();
        }
    }
}
