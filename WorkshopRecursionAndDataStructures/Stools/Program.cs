namespace Stools
{
    using System;

    public class Stool
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Stool(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    class Program
    {
        static Stool[] stools;
        private static int n;
        private static int[,,] memo;

        static int MaxHeight(int used, int top, int side)
        {
            if (Program.memo[used, top, side] != 0)
            {
                return Program.memo[used, top, side];
            }

            if (used == (1 << top))
            {
                if (side == 0)
                {
                    return Program.stools[top].X;
                }
                if (side == 1)
                {
                    return Program.stools[top].Y;
                }

                return Program.stools[top].Z;
            }

            int fromStools = used ^ (1 << top);

            int sideX = (side == 0) ? Program.stools[top].Y : Program.stools[top].X;
            int sideY = (side == 2) ? Program.stools[top].Y : Program.stools[top].Z;
            int sideH = Program.stools[top].X + Program.stools[top].Y + Program.stools[top].Z - sideX - sideY;

            int result = sideH;

            for (int i = 0; i < Program.n; i++)
            {
                if (((fromStools >> i) & 1) == 1)
                {

                    // side of stools[i] == 0;
                    if (Program.stools[i].Y >= sideX && Program.stools[i].Z >= sideY
                        || Program.stools[i].Y >= sideY && Program.stools[i].Z >= sideX)
                    {
                        result = Math.Max(result, Program.MaxHeight(fromStools, i, 0) + sideH);
                    }

                    if (Program.stools[i].X == Program.stools[i].Y && Program.stools[i].X == Program.stools[i].Z)
                    {
                        continue;
                    }

                    // side of stools[i] == 1;
                    if (Program.stools[i].X >= sideX && Program.stools[i].Z >= sideY
                        || Program.stools[i].X >= sideY && Program.stools[i].Z >= sideX)
                    {
                        result = Math.Max(result, Program.MaxHeight(fromStools, i, 1) + sideH);
                    }

                    // side of stools[i] == 2;
                    if (Program.stools[i].X >= sideX && Program.stools[i].Y >= sideY
                        || Program.stools[i].X >= sideY && Program.stools[i].Y >= sideX)
                    {
                        result = Math.Max(result, Program.MaxHeight(fromStools, i, 2) + sideH);
                    }
                }

            }

            Program.memo[used, top, side] = result;
            return result;
        }

        static void Main()
        {
            Program.n = int.Parse(Console.ReadLine());
            Program.stools = new Stool[Program.n];
            Program.memo = new int[1 << Program.n, Program.n, 3];
            //memo = new int[1 << n, 16, 4];

            int result = 0;

            for (int i = 0; i < Program.n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                Program.stools[i] = new Stool(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]));
            }

            for (int i = 0; i < Program.n; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    result = Math.Max(result, Program.MaxHeight((1 << Program.n) - 1, i, j));
                }
            }

            Console.WriteLine(result);
        }
    }
}