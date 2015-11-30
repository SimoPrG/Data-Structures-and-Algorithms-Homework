// Implement the data structure "hash table" in a class HashTable<K, T>. Keep the data in array of
// lists of key-value pairs(LinkedList<KeyValuePair<K, T>>[]) with initial capacity of 16. When the
// hash table load runs over 75%, perform resizing to 2 times larger capacity.Implement the
// following methods and properties: Add(key, value), Find(key)value, Remove(key), Count, Clear(),
// this[], Keys. Try to make the hash table to support iterating over its elements with foreach.

namespace HashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A new shiny hash table with key-value pairs
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the Hash table</typeparam>
    /// <typeparam name="TValue">The type of values in the Hash table</typeparam>
    public class HashTable<TKey,TValue> : IEnumerable<KeyValuePair<TKey,TValue>>
    {
        private const string CapacityZeroOrNegativeErrorMessage = "Initial HashTable size can not be less than or equal to 0!";

        private const int InitialCapacity = 16;
        private const double LoadFactor = 0.75;

        private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;
        private int occupiedBucketsCounter;
        private int elementsCounter;

        /// <summary>
        /// Empty Constructor that initializes the hash table with the default initial size
        /// </summary>
        public HashTable()
            : this(InitialCapacity) { }

        /// <summary>
        /// Constructor that initializes the hash table with predefined capacity
        /// </summary>
        /// <param name="capacity">The initial size of the Hash table</param>
        public HashTable(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException(CapacityZeroOrNegativeErrorMessage);
            }
            this.buckets = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
            this.occupiedBucketsCounter = 0;
            this.elementsCounter = 0;
        }

        /// <summary>
        /// Constructor that initializes the hash table with predefined capacity
        /// </summary>
        /// <param name="capacity">The initial size of the Hash table</param>
        /// <param name="hashTable">Another Hash table to include in this one</param>
        public HashTable(int capacity, HashTable<TKey,TValue> hashTable)
            : this(capacity)
        {
            foreach (var pair in hashTable)
            {
                this.Add(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Add a new key-value pair to the HashTable
        /// </summary>
        /// <param name="key">The key from the key-value pair to add</param>
        /// <param name="value">The value from the key-value pair to add</param>
        public void Add(TKey key, TValue value)
        {
            this.CheckAndGrow();

            var elementToAdd = new KeyValuePair<TKey,TValue>(key,value);

            int position = this.GetBucketPosition(key);

            if (this.buckets[position] == null)
            {
                this.buckets[position] = new LinkedList<KeyValuePair<TKey, TValue>>();
                this.buckets[position].AddFirst(elementToAdd);

                //only when we create a list in a table slot we increase it's positions taken
                this.occupiedBucketsCounter++;
            }
            else
            {
                this.Remove(key);

                if (this.buckets[position].Count == 0)
                {
                    //being an empty linked list also count as a empty bucket spot
                    this.occupiedBucketsCounter++;
                }

                this.buckets[position].AddLast(elementToAdd);
            }

            this.elementsCounter++;
        }

        /// <summary>
        /// Finds a <typeparamref name="TValue"/> value by givven <typeparamref name="TKey"/> key
        /// </summary>
        /// <param name="key">The key from the key-value pair to find</param>
        /// <returns><typeparamref name="TValue"/> value or default</returns>
        public bool Find(TKey key, out TValue value)
        {
            int position = this.GetBucketPosition(key);

            if (this.buckets[position] != null && this.buckets[position].Count != 0)
            {
                foreach (var pair in this.buckets[position])
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        return true;
                    }
                }
            }
            value = default(TValue);
            return false;
        }

        /// <summary>
        /// Removes a <typeparamref name="TValue"/> value by given <typeparamref name="TKey"/> key
        /// </summary>
        /// <param name="key">The key from the key-value pair to remove</param>
        public void Remove(TKey key)
        {
            int position = this.GetBucketPosition(key);

            if (this.buckets[position] != null && this.buckets[position].Count != 0)
            {
                TValue valueToRemove;

                if (this.Find(key,out valueToRemove))
	            {
                    var nodeToRemove = this.buckets[position].First(x => x.Key.Equals(key));

                    this.buckets[position].Remove(nodeToRemove);

                    this.elementsCounter--;

                    if (this.buckets[position].Count == 0)
                    {
                        this.occupiedBucketsCounter--;
                    }
	            }
            }
        }

        /// <summary>
        /// Clears all the elements from the HashTable
        /// </summary>
        public void Clear()
        {
            this.buckets = new LinkedList<KeyValuePair<TKey, TValue>>[this.buckets.Length];
            this.occupiedBucketsCounter = 0;
            this.elementsCounter = 0;
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue valueToReturn;

                this.Find(key, out valueToReturn);

                return valueToReturn;
            }

            set
            {
                this.Add(key, value);
            }
        }

        /// <summary>
        /// The number of elements in the Hash Table
        /// </summary>
        /// <returns><typeparamref name="int"/>The total elements in the Hash Table</returns>
        public int Count
        {
            get
            {
                return this.elementsCounter;
            }
        }

        /// <summary>
        /// A collection of all the keys in the Hash Table
        /// </summary>
        /// <returns>An array of <typeparamref name="TKey"/> elements</returns>
        public TKey[] Keys
        {
            get
            {
                var listOfKeys = new List<TKey>(this.elementsCounter);

                foreach (var pair in this)
                {
                    listOfKeys.Add(pair.Key);
                }

                return listOfKeys.ToArray();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var pair in this)
            {
                sb.AppendFormat("({0}->{1}) ; ", pair.Key, pair.Value);
            }

            return sb.ToString().TrimEnd(new char[] { ';', ' ' });
        }


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var list in this.buckets)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetBucketPosition(TKey key)
        {
            var position = key.GetHashCode() % this.buckets.Length;

            if (position < 0)
            {
                position = position * (-1);
            }

            return position;
        }

        private void CheckAndGrow()
        {
            if (this.occupiedBucketsCounter >= this.buckets.Length * LoadFactor)
            {
                var newHashTable = new HashTable<TKey, TValue>(this.buckets.Length * 2);

                foreach (var pair in this)
                {
                    newHashTable.Add(pair.Key, pair.Value);
                }

                this.buckets = newHashTable.buckets;
            }
        }
    }
}
