namespace Workshop01JedyMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var jedis = Console.ReadLine().Split(' ');
            var masters = new Queue<string>();
            var knights = new Queue<string>();
            var paladins = new Queue<string>();
			
            for (int i = 0; i < n; i++)
            {
                switch (jedis[i][0])
                {
                    case 'm':
                        masters.Enqueue(jedis[i]);
                        break;
                    case 'k':
                        knights.Enqueue(jedis[i]);
                        break;
                    case 'p':
                        paladins.Enqueue(jedis[i]);
                        break;
                }
            }

            var output = new StringBuilder();
            while (masters.Count > 0)
            {
                output.Append(masters.Dequeue() + ' ');
            }

            while (knights.Count > 0)
            {
                output.Append(knights.Dequeue() + ' ');
            }

            while (paladins.Count > 0)
            {
                output.Append(paladins.Dequeue() + ' ');
            }

            Console.Write(output.ToString().TrimEnd());
        }
    }
}
