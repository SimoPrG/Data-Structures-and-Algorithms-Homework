namespace MyLinkedList
{
    using System;

    /// <summary>
    ///     Represents dynamic list implementation
    /// </summary>
    public class LinkedList<T>
    {
        private ListItem head;
        private ListItem tail;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        /// <summary>
        ///     Gets the number of elements in the list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Gets or sets the element on the specified position
        /// </summary>
        /// <param name="index">
        ///     The position of the element [0 … count-1]
        /// </param>
        /// <returns>The object at the specified index</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     Index is invalid
        /// </exception>
        public T this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalid index: " + index);
                }

                var currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode.Element;
            }

            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalid index: " + index);
                }

                var currentNode = this.head;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Element = value;
            }
        }

        /// <summary>
        ///     Add element at the end of the list
        /// </summary>
        /// <param name="item">The element you want to add</param>
        public void Add(T item)
        {
            if (this.head == null)
            {
                // We have empty list
                this.head = new ListItem(item);
                this.tail = this.head;
            }
            else
            {
                // We have non-empty list
                var newNode = new ListItem(item, this.tail);
                this.tail = newNode;
            }

            this.Count++;
        }

        /// <summary>
        ///     Removes and returns element on the specific index
        /// </summary>
        /// <param name="index">
        ///     The index of the element you want to remove
        /// </param>
        /// <returns>The removed element</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Index is invalid</exception>
        public object Remove(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Invalid index: " + index);
            }

            // Find the element at the specified index
            int currentIndex = 0;
            var currentNode = this.head;
            ListItem prevListItem = null;
            while (currentIndex < index)
            {
                prevListItem = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            // Remove the element
            this.Count--;
            if (this.Count == 0)
            {
                this.head = null;
            }
            else if (prevListItem == null)
            {
                this.head = currentNode.Next;
            }
            else
            {
                prevListItem.Next = currentNode.Next;
            }

            // Find last element
            ListItem lastElement = null;
            if (this.head != null)
            {
                lastElement = this.head;
                while (lastElement.Next != null)
                {
                    lastElement = lastElement.Next;
                }
            }

            this.tail = lastElement;
            return currentNode.Element;
        }

        /// <summary>
        ///     Removes the specified item and return its index
        /// </summary>
        /// <param name="item">The item for removal</param>
        /// <returns>The index of the element or -1 if does not exist</returns>
        public int Remove(object item)
        {
            // Find the element containing searched item
            int currentIndex = 0;
            var currentNode = this.head;
            ListItem prevListItem = null;
            while (currentNode != null)
            {
                if ((currentNode.Element != null && currentNode.Element.Equals(item)) ||
                    (currentNode.Element == null) && (item == null))
                {
                    break;
                }

                prevListItem = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            if (currentNode != null)
            {
                // Element is found in the list. Remove it
                this.Count--;
                if (this.Count == 0)
                {
                    this.head = null;
                }
                else if (prevListItem == null)
                {
                    this.head = currentNode.Next;
                }
                else
                {
                    prevListItem.Next = currentNode.Next;
                }

                // Find last element
                ListItem lastElement = null;
                if (this.head != null)
                {
                    lastElement = this.head;
                    while (lastElement.Next != null)
                    {
                        lastElement = lastElement.Next;
                    }
                }

                this.tail = lastElement;
                return currentIndex;
            }

            // Element is not found in the list
            return -1;
        }

        /// <summary>
        ///     Searches for given element in the list
        /// </summary>
        /// <param name="item">The item you are searching for</param>
        /// <returns>
        ///     the index of the first occurrence of the element
        ///     in the list or -1 when not found
        /// </returns>
        public int IndexOf(T item)
        {
            int index = 0;
            var current = this.head;
            while (current != null)
            {
                if ((current.Element != null && current.Element.Equals(item)) ||
                    (current.Element == null) && (item == null))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1;
        }

        /// <summary>
        ///     Check if the specified element exists in the list
        /// </summary>
        /// <param name="item">The item you are searching for</param>
        /// <returns>
        ///     True if the element exists or false otherwise
        /// </returns>
        public bool Contains(T item)
        {
            int index = this.IndexOf(item);
            bool found = index != -1;
            return found;
        }

        private class ListItem
        {
            public ListItem(T element, ListItem prevListItem)
            {
                this.Element = element;
                prevListItem.Next = this;
            }

            public ListItem(T element)
            {
                this.Element = element;
                this.Next = null;
            }

            public T Element { get; set; }

            public ListItem Next { get; set; }
        }
    }
}