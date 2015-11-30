namespace Palindromize
{
    using System;
    using System.Text;

    public static class Program
    {
        public static void Main()
        {
            string str = Console.ReadLine();

            var palindromize = Palindromize(str);
            var answer = palindromize;

            Console.WriteLine(answer);
        }

        private static bool IsPalindrome(StringBuilder str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static string Palindromize(string str)
        {
            var builder = new StringBuilder(str);
            int thePosition = builder.Length;
            for (int i = 0; i < str.Length; i++)
            {
                if (IsPalindrome(builder))
                {
                    return builder.ToString();
                }

                builder.Insert(thePosition, builder[i]);
            }

            return "ne6to se obyrka";
        }
    }
}
