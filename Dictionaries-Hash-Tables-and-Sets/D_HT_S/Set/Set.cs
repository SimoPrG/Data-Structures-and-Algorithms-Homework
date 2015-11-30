// Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K, T> to
// hold the elements.Implement all standard set operations like Add(T), Find(T), Remove(T), Count,
// Clear(), union and intersect.

namespace Set
{
    using System.Collections.Generic;
    using HashTable;

    /// <summary>
    /// A new shiny set of elements
    /// </summary>
    /// <typeparam name="T">The type of elements in the Set</typeparam>
    public class Set<T> : IEnumerable<T>
    {
        private readonly HashTable<int, T> elements;

        /// <summary>
        /// Empty Constructor that initializes the Set
        /// </summary>
        public Set()
        {
            this.elements = new HashTable<int, T>();
        }

        /// <summary>
        /// Add a new <typeparamref name="T"/> element to the Set 
        /// </summary>
        /// <param name="element">The element to add to the Set</param>
        public void Add(T element)
        {
            this.elements.Add(element.GetHashCode(), element);
        }

        /// <summary>
        /// Removes a <typeparamref name="T"/> element from the Set 
        /// </summary>
        /// <param name="element">The element to remove from the Set</param>
        public void Remove(T element)
        {
            this.elements.Remove(element.GetHashCode());
        }

        /// <summary>
        /// Finds a <typeparamref name="T"/> value by given <typeparamref name="K"/> key
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <returns><typeparamref name="T"/> value or default</returns>
        public T Find(T element)
        {
            T returnedElement;
            if(this.elements.Find(element.GetHashCode(), out returnedElement))
            {
                return returnedElement;
            }

            return default(T);
        }

        /// <summary>
        /// The number of elements in the Set
        /// </summary>
        /// <returns><typeparamref name="int"/>The total elements in the Set</returns>
        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        /// <summary>
        /// Clears all the elements from the Set
        /// </summary>
        public void Clear()
        {
            this.elements.Clear();
        }

        /// <summary>
        /// Produces a Set of <typeparamref name="T"/> values intersected with another Set <typeparamref name="K"/> key
        /// </summary>
        /// <param name="other">The other Set to intersect with</param>
        /// <returns><typeparamref name="Set<T>"/></returns>
        public Set<T> Intersect(Set<T> other)
        {
            Set<T> newSet = new Set<T>();

            foreach (var element in this)
            {
                foreach (var otherElement in other)
                {
                    if (element.Equals(otherElement))
                    {
                        newSet.Add(element);
                    }
                }
            }

            return newSet;
        }

        /// <summary>
        /// Produces a Set of <typeparamref name="T"/> values united with another Set <typeparamref name="K"/> key
        /// </summary>
        /// <param name="other">The other Set to union with</param>
        /// <returns><typeparamref name= Set<T>"/></returns>
        public Set<T> Union(Set<T> other)
        {
            Set<T> newSet = new Set<T>();

            foreach (var element in this)
            {
                newSet.Add(element);
            }

            foreach (var element in other)
            {
                newSet.Add(element);
            }

            return newSet;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this.elements)
            {
                yield return pair.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}
