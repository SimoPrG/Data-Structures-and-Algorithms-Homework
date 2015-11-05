namespace HashTable
{
    using System;

    public class Testing
    {
        public static void Main()
        {
            var HashTable = new HashTable<int, string> { { 3, "ar" } };


            HashTable[2] = "asd";

            string indexCheck = HashTable[2];

            Console.WriteLine("toString:");
            Console.WriteLine(HashTable);

            Console.WriteLine("indexer:");
            Console.WriteLine(HashTable[2]);
            Console.WriteLine(indexCheck);

            Console.WriteLine("keys:");
            var keysChecker = HashTable.Keys;

            foreach (int key in keysChecker)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("count:");
            Console.WriteLine(HashTable.Count);
            Console.WriteLine("remove:");
            HashTable.Remove(4);

            Console.WriteLine(HashTable[2]);

            HashTable.Remove(2);

            Console.WriteLine(HashTable[2]);
            Console.WriteLine("count:");
            Console.WriteLine(HashTable.Count);

            string res;
            bool findChecker = HashTable.Find(3, out res);
            Console.WriteLine("Find value by key 3:");
            Console.WriteLine(res);
            Console.WriteLine(findChecker);

            Console.WriteLine(HashTable);
            Console.WriteLine("clear");
            HashTable.Clear();
            Console.WriteLine(HashTable);
            Console.WriteLine("----");
            Console.WriteLine("resize");

            for (int i = 0; i < 100; i++)
            {
                HashTable.Add(i, i.ToString());
            }

            Console.WriteLine(HashTable);
        }
    }
}
